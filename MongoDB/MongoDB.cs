﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;

namespace Mongo
{
    public delegate void ProgressUpdate(int e);

    public class MongoDBHelper
    {
        public MongoCollection<BsonDocument> collection;
        public MongoCollection<BsonDocument> failCollection;
        public Hashtable successAllConfigTable;
        public Hashtable failAllConfigTable;
        public Hashtable successConfigTable;
        public Hashtable failConfigTable;
        public event ProgressUpdate OnProgressUpdate;
        public MongoDBHelper(string serverAddr, string dbName, string collectionName)
        {
            MongoClient client = new MongoClient("mongodb://" + serverAddr);
            MongoServer server = client.GetServer();
            MongoDatabase mongoDB = server.GetDatabase(dbName);
            collection = mongoDB.GetCollection(collectionName);
            failCollection = mongoDB.GetCollection("UnitTestFailures");
        }
        /// <summary>
        /// Get the number of total test runs and failed test runs
        /// </summary>
        /// <returns>array contains total test runs and failed test run
        ///          index 0 is total, 1 is fail</returns>
        public int[] GetNumTotalAndFail(int days)
        {
            DateTime date = DateTime.Now.Subtract(TimeSpan.FromDays(days));
            var dateQuery = Query.And(Query.GT("Date", date));
            MongoCursor<BsonDocument> cursor = collection.Find(dateQuery);
            int numTotalTests = 0;
            int numFailureTests = 0;
            int[] ret = new int[2];
            foreach (BsonDocument doc in cursor)
            {
                if (doc != null)
                {
                    BsonDocument testRun = doc["TestRun"].AsBsonDocument;
                    BsonArray configs = testRun["Configuration"].AsBsonArray;
                    foreach (BsonDocument config in configs)
                    {
                        BsonArray testResults = config["test-results"].AsBsonArray;
                        foreach (BsonDocument testResult in testResults)
                        {
                            numTotalTests += Convert.ToInt32(testResult["@total"].AsString);
                            numFailureTests += Convert.ToInt32(testResult["@failures"].AsString);
                        }
                    }
                }
            }
            ret[0] = numTotalTests;
            ret[1] = numFailureTests;
            return ret;
        }

        /// <summary>
        /// Get project-automation hashtable, key is the project name, 
        /// automations associated with projectname are the values(type of ArrayList)
        /// </summary>
        /// <returns>Hashtable that contains project-automation data</returns>
        public Hashtable GetProjectAutomationTable(BsonObjectId id, int days)
        {
            DateTime date = DateTime.Now.Subtract(TimeSpan.FromDays(days));
            List<BsonValue> projectNames = collection.Distinct("TestRun.Configuration.test-results.@project-name").ToList();
            Hashtable projectAutomationTable = new Hashtable();
            foreach (string project in projectNames)
            {
                IMongoQuery query;
                if (id != null)
                {
                    query = Query.And(Query.EQ("_id", id), Query.EQ("TestRun.Configuration.test-results.@project-name", project));
                }
                else
                {
                    query = Query.And(Query.GT("Date", date), Query.EQ("TestRun.Configuration.test-results.@project-name", project));
                }
                MongoCursor<BsonDocument> testCursor = collection.Find(query).SetLimit(1);
                ArrayList automationNames = new ArrayList();
                foreach (BsonDocument doc in testCursor)
                {
                    BsonDocument testRun = doc["TestRun"].AsBsonDocument;
                    BsonArray configs = testRun["Configuration"].AsBsonArray;
                    foreach (BsonDocument config in configs)
                    {
                        BsonArray testResults = config["test-results"].AsBsonArray;
                        foreach (BsonDocument testResult in testResults)
                        {
                            if (Convert.ToInt32(testResult["@total"]) != 0 && (testResult["@project-name"].Equals(project) == true))
                            {
                                BsonDocument testSuite = testResult["test-suite"].AsBsonDocument;
                                BsonDocument results = testSuite["results"].AsBsonDocument;
                                BsonArray testCase = results["test-case"].AsBsonArray;
                                automationNames = new ArrayList();
                                BsonDocument test = testCase[0].AsBsonDocument;
                                foreach (BsonDocument caseResult in testCase)
                                {
                                    automationNames.Add(caseResult["@name"].AsString);
                                }
                            }
                        }
                    }
                }
                projectAutomationTable.Add(project, automationNames);
            }
            return projectAutomationTable;
        }

        /// <summary>
        /// Analyze the data in the Mongodb, and put associated data in to different tables
        /// </summary>
        /// <returns>Returns true when finshed analyzing data</returns>
        public bool AnalyzeData(int dropDownIndex, int days)
        {
            DateTime date = DateTime.Now.Subtract(TimeSpan.FromDays(days));
            SortByBuilder sbb = new SortByBuilder();
            sbb.Descending("_id");
            var lastDocs = collection.FindAllAs<BsonDocument>().SetSortOrder(sbb).SetLimit(15);
            Hashtable idRunNameTable = new Hashtable();
            ArrayList keyList = new ArrayList();
            foreach (BsonDocument lastDoc in lastDocs)
            {
                BsonObjectId id = lastDoc["_id"].AsObjectId;
                BsonDocument testRun = lastDoc["TestRun"].AsBsonDocument;
                string testRunName = testRun["@testRunName"].AsString;
                string userName = testRun["@userName"].AsString;
                string timeStamp = testRun["@timeStamp"].AsString;
                string hashtableKey = @"""" + testRunName + @""" """ + userName + @""" """ + timeStamp + @"""";
                idRunNameTable.Add(hashtableKey, id);
                //Track the order of each test run
                keyList.Add(hashtableKey);
            }
            BsonObjectId objectId = null;
            if (dropDownIndex >= 0)
               objectId = (BsonObjectId) idRunNameTable[keyList[dropDownIndex]];
            bool ret = false;
            successAllConfigTable = new Hashtable();
            failAllConfigTable = new Hashtable();
            successConfigTable = new Hashtable();
            failConfigTable = new Hashtable();
            //var projectNames = collection.Distinct("TestRun.Configuration.test-results.@project-name").ToList();
            Hashtable projectAutomationTable = this.GetProjectAutomationTable(objectId, days);
            var filteredTable = projectAutomationTable.Cast<DictionaryEntry>().Where(x => ((ArrayList)x.Value).Count != 0).ToDictionary(x => (string)x.Key, x=> (ArrayList)x.Value);
            var projectNames = filteredTable.Keys;
            int progress = 0;
            int totalNumProject = projectNames.Count;
            foreach (string project in projectNames)
            {
                ArrayList automationNameList = (ArrayList)filteredTable[project];
                int report = progress * 100 / totalNumProject;
                OnProgressUpdate(report);
                foreach (string automation in automationNameList)
                {
                    MongoCursor<BsonDocument> testSuccess = null;
                    if (dropDownIndex == -1)
                    {
                        var queryResults1 = Query.And(Query.GT("Date", date),
                                                Query.ElemMatch("TestRun.Configuration.test-results",
                                                    Query.And(
                                                        Query.EQ("@project-name", project),
                                                        Query.ElemMatch("test-suite.results.test-case",
                                                            Query.And(
                                                                Query.EQ("@name", automation),
                                                                Query.EQ("@success", "True"))))));
                        testSuccess = collection.Find(queryResults1);
                    }
                    else
                    {
                        var queryResults1 = Query.And(Query.EQ("_id", objectId),
                                            Query.ElemMatch("TestRun.Configuration.test-results",
                                                Query.And(
                                                    Query.EQ("@project-name", project),
                                                    Query.ElemMatch("test-suite.results.test-case",
                                                        Query.And(
                                                            Query.EQ("@name", automation),
                                                            Query.EQ("@success", "True"))))));

                        testSuccess = collection.Find(queryResults1);
                    }
                    MongoCursor<BsonDocument> testAll;
                    if (dropDownIndex == -1)
                    {
                        var queryResults2 = Query.And(Query.GT("Date", date),
                                                Query.ElemMatch("TestRun.Configuration.test-results",
                                                    Query.And(
                                                        Query.EQ("@project-name", project),
                                                                Query.ElemMatch("test-suite.results.test-case",
                                                                Query.EQ("@name", automation)))));
                        testAll = collection.Find(queryResults2);
                    }
                    else
                    {
                        var queryResults2 = Query.And(Query.EQ("_id", objectId),
                        Query.ElemMatch("TestRun.Configuration.test-results",
                            Query.And(
                                Query.EQ("@project-name", project),
                                        Query.ElemMatch("test-suite.results.test-case",
                                        Query.EQ("@name", automation)))));
                        testAll = collection.Find(queryResults2);
                    }
                    MongoCursor<BsonDocument> testFail;
                    if (dropDownIndex == -1)
                    {
                        var queryResults3 = Query.And(Query.GT("Date", date),
                                                Query.ElemMatch("TestRun.Configuration.test-results",
                                                    Query.And(
                                                        Query.EQ("@project-name", project),
                                                                Query.ElemMatch("test-suite.results.test-case",
                                                                    Query.And(
                                                                        Query.EQ("@name", automation),
                                                                        Query.EQ("@success", "False"))))));
                        testFail = collection.Find(queryResults3);
                    }
                    else
                    {
                        var queryResults3 = Query.And(Query.EQ("_id", objectId),
                                                Query.ElemMatch("TestRun.Configuration.test-results",
                                                    Query.And(
                                                        Query.EQ("@project-name", project),
                                                                Query.ElemMatch("test-suite.results.test-case",
                                                                    Query.And(
                                                                        Query.EQ("@name", automation),
                                                                        Query.EQ("@success", "False"))))));
                        testFail = collection.Find(queryResults3);
                    }
                    if (testSuccess.Count() != testAll.Count() && testSuccess.Count() != 0)
                    {
                        IEnumerable<BsonDocument> diffs = testAll.Except(testSuccess);
                        foreach (BsonDocument diffBson in diffs)
                        {
                            BsonDocument testRun = diffBson["TestRun"].AsBsonDocument;
                            string version = testRun["@runtimeVersion"].AsString;
                            var failQuery = Query.And(
                                                Query.EQ("@project-name", project), Query.EQ("@runtime-version", version),
                                                Query.ElemMatch("failures.automation",
                                                    Query.And(
                                                        Query.EQ("@name", automation), Query.EQ("@success", "False"))));
                            MongoCursor<BsonDocument> failCursor = failCollection.Find(failQuery);
                            List<Automation> failureAutomationList = new List<Automation>();
                            BsonArray failAutomation = new BsonArray();
                            if (failCursor.Count() != 0)
                            {
                                BsonDocument failTypeDoc = failCursor.First();
                                BsonDocument failures = failTypeDoc["failures"].AsBsonDocument;
                                var failAutoJson = failures.ToJson();
                                failureAutomationList = JsonConvert.DeserializeObject<Failures>(failAutoJson).automation;
                            }
                            string failureType = string.Empty;
                            string failureMsg = string.Empty;
                            if (failureAutomationList.Count != 0)
                            {
                                var failAutomationWithName = failureAutomationList.Find(x => x.name.Equals(automation));
                                var failStatus = failAutomationWithName.status;
                                failureType = failStatus.failureType;
                                failureMsg = failStatus.message;
                            }

                            BsonArray configs = testRun["Configuration"].AsBsonArray;
                            foreach (BsonDocument config in configs)
                            {
                                var configJson = config.ToJson();
                                var configDeserial = JsonConvert.DeserializeObject<Configuration>(configJson);
                                string templateName = configDeserial.templateName;
                                var testResultsDeserial = configDeserial.testResults;
                                var testResultOnProject = testResultsDeserial.Find(x => x.projectName.Equals(project));
                                var testSuite = testResultOnProject.testSuite;
                                var testResults = testSuite.results;
                                var testCase = testResults.TestCases;
                                var unitTestResult = testCase.Find(x => x.name.Equals(automation));
                                //To be done
                                string errorMsg = string.Empty;

                                if (failCursor.Count() == 0)
                                {
                                    failureType = "Failure";
                                }
                                if (failConfigTable.ContainsKey(templateName) == false)
                                {
                                    Hashtable projectTable = new Hashtable();
                                    ArrayList list = new ArrayList();
                                    Hashtable detailTable = new Hashtable();
                                    list.Add(failureType);
                                    list.Add(version);
                                    list.Add(errorMsg);
                                    detailTable.Add(automation, list);
                                    projectTable.Add(project, detailTable);
                                    failConfigTable.Add(templateName, projectTable);
                                }
                                else
                                {
                                    Hashtable table = (Hashtable)failConfigTable[templateName];
                                    if (table == null)
                                    {
                                        table = new Hashtable();
                                    }
                                    if (table.ContainsKey(project))
                                    {
                                        Hashtable errorTable = (Hashtable)table[project];
                                        if (errorTable.ContainsKey(automation) == false)
                                        {
                                            ArrayList list = new ArrayList();
                                            list.Add(failureType);
                                            list.Add(version);
                                            list.Add(errorMsg);
                                            errorTable.Add(automation, list);
                                            table[project] = errorTable;
                                        }
                                    }
                                    else
                                    {
                                        Hashtable errorTable = new Hashtable();
                                        ArrayList list = new ArrayList();
                                        list.Add(failureType);
                                        list.Add(version);
                                        list.Add(errorMsg);
                                        errorTable.Add(automation, list);
                                        table.Add(project, errorTable);
                                    }
                                    failConfigTable[templateName] = table;
                                }
                            }
                        }
                    }
                    if (testAll.Count() != testFail.Count() && testFail.Count() != 0)
                    {
                        IEnumerable<BsonDocument> diff = testAll.Except(testFail);
                        foreach (BsonDocument diffBson in diff)
                        {
                            BsonDocument testRun = diffBson["TestRun"].AsBsonDocument;
                            string version = testRun["@runtimeVersion"].AsString;
                            BsonArray configs = testRun["Configuration"].AsBsonArray;
                            foreach (BsonDocument config in configs)
                            {
                                var configJson = config.ToJson();
                                var configDeserial = JsonConvert.DeserializeObject<Configuration>(configJson);
                                string templateName = configDeserial.templateName;
                                var testResultsDeserial = configDeserial.testResults;
                                var testResultOnProject = testResultsDeserial.Find(x => x.projectName.Equals(project));
                                var testSuite = testResultOnProject.testSuite;
                                var testResults = testSuite.results;
                                var testCase = testResults.TestCases;
                                var unitTestResult = testCase.Find(x => x.name.Equals(automation));
                                if (successConfigTable.ContainsKey(templateName) == false)
                                {
                                    Hashtable projectTable = new Hashtable();
                                    Hashtable detailTable = new Hashtable();
                                    ArrayList list = new ArrayList();
                                    list.Add(version);
                                    detailTable.Add(automation, list);
                                    projectTable.Add(project, detailTable);
                                    successConfigTable.Add(templateName, projectTable);
                                }
                                else
                                {
                                    Hashtable table = (Hashtable)successConfigTable[templateName];
                                    if (table == null)
                                    {
                                        table = new Hashtable();
                                    }
                                    if (table.ContainsKey(project) == true)
                                    {
                                        Hashtable detailTable = (Hashtable)table[project];
                                        ArrayList list = new ArrayList();
                                        if (detailTable.ContainsKey(automation) == false)
                                        {
                                            list.Add(version);
                                            detailTable.Add(automation, list);
                                        }
                                        else
                                        {
                                            list = (ArrayList)detailTable[automation];
                                            list.Add(version);
                                            detailTable[automation] = list;
                                        }
                                        table[project] = detailTable;
                                    }
                                    else
                                    {
                                        Hashtable detailTable = new Hashtable();

                                        ArrayList list = new ArrayList();
                                        if (detailTable.ContainsKey(automation) == false)
                                        {
                                            list.Add(version);
                                            detailTable.Add(automation, list);
                                        }
                                        table.Add(project, detailTable);
                                    }
                                    successConfigTable[templateName] = table;
                                }
                            }
                        }
                    }
                    if (testFail.Count() == 0)
                    {
                        BsonDocument first = testSuccess.First();
                        string version = this.GetRuntimeVersion(first);
                        if (successAllConfigTable.ContainsKey(project) == false)
                        {
                            ArrayList list = new ArrayList();
                            list.Add(version);
                            Hashtable table = new Hashtable();
                            table.Add(automation, list);
                            successAllConfigTable.Add(project, table);
                        }
                        else
                        {
                            Hashtable table = (Hashtable)successAllConfigTable[project];
                            ArrayList list = (ArrayList)table[automation];
                            if (list == null)
                            {
                                list = new ArrayList();
                            }
                            list.Add(version);
                            table[automation] = list;
                            successAllConfigTable[project] = table;
                        }
                    }

                    if (testSuccess.Count() == 0)
                    {
                        BsonDocument first = testFail.First();
                        string version = this.GetRuntimeVersion(first);
                        var failQuery = Query.And(
                                            Query.EQ("@project-name", project), Query.EQ("@runtime-version", version),
                                            Query.ElemMatch("failures.automation",
                                                Query.And(
                                                    Query.EQ("@name", automation), Query.EQ("@success", "False"))));
                        MongoCursor<BsonDocument> failCursor = failCollection.Find(failQuery);
                        List<Automation> failureAutomationList = new List<Automation>();
                        BsonArray failAutomation = new BsonArray();
                        if (failCursor.Count() != 0)
                        {
                            BsonDocument failTypeDoc = failCursor.First();
                            BsonDocument failures = failTypeDoc["failures"].AsBsonDocument;
                            var failAutoJson = failures.ToJson();
                            failureAutomationList = JsonConvert.DeserializeObject<Failures>(failAutoJson).automation;
                        }
                        string failureType = string.Empty;
                        string failureMsg = string.Empty;
                        if (failureAutomationList.Count != 0)
                        {
                            var failAutomationWithName = failureAutomationList.Find(x => x.name.Equals(automation));
                            var failStatus = failAutomationWithName.status;
                            failureType = failStatus.failureType;
                            failureMsg = failStatus.message;
                        }
                        if (failCursor.Count() == 0)
                        {
                            failureType = "Failure";
                        }
                        string errorMsg = string.Empty;
                        foreach (BsonDocument fail in testFail)
                        {
                            BsonDocument testRun = fail["TestRun"].AsBsonDocument;
                            BsonArray configs = testRun["Configuration"].AsBsonArray;
                            foreach (BsonDocument config in configs)
                            {
                                var configJson = config.ToJson();
                                var configDeserial = JsonConvert.DeserializeObject<Configuration>(configJson);
                                string templateName = configDeserial.templateName;
                                var testResultsDeserial = configDeserial.testResults;
                                var testResultOnProject = testResultsDeserial.Find(x => x.projectName.Equals(project));
                                var testSuite = testResultOnProject.testSuite;
                                var testResults = testSuite.results;
                                var testCase = testResults.TestCases;
                                var unitTestResult = testCase.Find(x => x.name.Equals(automation));
                                //To be done
                                errorMsg = string.Empty;
                            }
                        }
                        if (failAllConfigTable.ContainsKey(project) == false)
                        {
                            ArrayList list = new ArrayList();
                            list.Add(failureType);
                            list.Add(version);
                            list.Add(errorMsg);
                            Hashtable table = new Hashtable();
                            table.Add(automation, list);
                            failAllConfigTable.Add(project, table);
                        }
                        else
                        {
                            Hashtable table = (Hashtable)failAllConfigTable[project];
                            ArrayList list = (ArrayList)table[automation];
                            if (list == null)
                            {
                                list = new ArrayList();
                            }
                            list.Add(failureType);
                            list.Add(version);
                            list.Add(errorMsg);
                            table[automation] = list;
                            failAllConfigTable[project] = table;
                        }
                    }
                }
                progress++;
            }
            OnProgressUpdate(100);
            ret = true;
            return ret;
        }

        private string GetRuntimeVersion(BsonDocument firstElement)
        {
            BsonDocument firtTestRun = firstElement["TestRun"].AsBsonDocument;
            return firtTestRun["@runtimeVersion"].AsString;
        }
    }
}

