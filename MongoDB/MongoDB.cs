using System;
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
        private DateTime mDate;
        public MongoDBHelper(string serverAddr, string dbName, string collectionName, int days)
        {
            MongoClient client = new MongoClient("mongodb://" + serverAddr);
            MongoServer server = client.GetServer();
            MongoDatabase mongoDB = server.GetDatabase(dbName);
            collection = mongoDB.GetCollection(collectionName);
            failCollection = mongoDB.GetCollection("UnitTestFailures");
            mDate = DateTime.Now.Subtract(TimeSpan.FromDays(days));
        }
        /// <summary>
        /// Get the number of total test runs and failed test runs
        /// </summary>
        /// <returns>array contains total test runs and failed test run
        ///          index 0 is total, 1 is fail</returns>
        public int[] GetNumTotalAndFail()
        {
            var dateQuery = Query.And(Query.GT("Date", mDate));
            //skip first inconsistant entry in current db.
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
        public Hashtable GetProjectAutomationTable()
        {
            var projectNames = collection.Distinct("TestRun.Configuration.test-results.@project-name").ToList();
            Hashtable projectAutomationTable = new Hashtable();
            foreach (string project in projectNames)
            {
                var query = Query.And(Query.GT("Date", mDate), Query.EQ("TestRun.Configuration.test-results.@project-name", project));
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
        public bool AnalyzeData()
        {
            bool ret = false;
            successAllConfigTable = new Hashtable();
            failAllConfigTable = new Hashtable();
            successConfigTable = new Hashtable();
            failConfigTable = new Hashtable();
            var projectNames = collection.Distinct("TestRun.Configuration.test-results.@project-name").ToList();
            Hashtable projectAutomationTable = this.GetProjectAutomationTable();

            int progress = 0;
            int totalNumProject = projectNames.Count;
            foreach (string project in projectNames)
            {
                ArrayList automationNameList = (ArrayList)projectAutomationTable[project];
                int report = progress * 100 / totalNumProject;
                OnProgressUpdate(report);
                foreach (string automation in automationNameList)
                {
                    var queryResults1 = Query.And(Query.GT("Date", mDate),
                                            Query.ElemMatch("TestRun.Configuration.test-results",
                                                Query.And(
                                                    Query.EQ("@project-name", project),
                                                    Query.ElemMatch("test-suite.results.test-case",
                                                        Query.And(
                                                            Query.EQ("@name", automation),
                                                            Query.EQ("@success", "True"))))));
                    MongoCursor<BsonDocument> testSuccess = collection.Find(queryResults1);
                    /*
                    if (testSuccess.Count() == 0 && automationNameList.Count != 1)
                    {
                        queryResults1 = Query.And(
                                            Query.GT("Date", mDate),
                                            Query.EQ("test-results.@project-name", project),
                                                Query.ElemMatch("test-run.test-results.test-suite.results.test-case",
                                                    Query.And(
                                                        Query.EQ("@name", automation),
                                                        Query.EQ("@success", "True"))));
                        testSuccess = collection.Find(queryResults1);
                    }
                    if (testSuccess.Count() == 0 && automationNameList.Count == 1)
                    {
                        queryResults1 = Query.And(
                                            Query.GT("Date", mDate), 
                                            Query.EQ("test-run.test-results.@project-name", project),
                                            Query.And(
                                                Query.EQ("test-run.test-results.test-suite.results.test-case.@name", automation),
                                                Query.EQ("test-run.test-results.test-suite.results.test-case.@success", "True")));
                        testSuccess = collection.Find(queryResults1);
                    }
                    */
                    var queryResults2 = Query.And(Query.GT("Date", mDate),
                                            Query.ElemMatch("TestRun.Configuration.test-results",
                                                Query.And(
                                                    Query.EQ("@project-name", project),
                                                            Query.ElemMatch("test-suite.results.test-case",
                                                            Query.EQ("@name", automation)))));
                    MongoCursor<BsonDocument> testAll = collection.Find(queryResults2);
                    /*
                    if (testAll.Count() == 0 && automationNameList.Count != 1)
                    {
                        queryResults2 = Query.And(
                                            Query.GT("Date", mDate),
                                            Query.EQ("test-results.@project-name", project),
                                                Query.ElemMatch("test-run.test-results.test-suite.results.test-case",
                                                    Query.And(
                                                        Query.EQ("@name", automation))));
                        testAll = collection.Find(queryResults2);
                    }
                    if (testAll.Count() == 0 && automationNameList.Count == 1)
                    {
                        queryResults2 = Query.And(
                                            Query.GT("Date", mDate),
                                            Query.EQ("test-results.@project-name", project),
                                                Query.ElemMatch("test-run.test-results.test-suite.results.test-case",
                                                    Query.And(
                                                        Query.EQ("@name", automation))));
                        testAll = collection.Find(queryResults2);
                    }
                     */
                    var queryResults3 = Query.And(Query.GT("Date", mDate),
                                            Query.ElemMatch("TestRun.Configuration.test-results",
                                                Query.And(
                                                    Query.EQ("@project-name", project),
                                                            Query.ElemMatch("test-suite.results.test-case",
                                                                Query.And(
                                                                    Query.EQ("@name", automation),
                                                                    Query.EQ("@success", "False"))))));
                    MongoCursor<BsonDocument> testFail = collection.Find(queryResults3);
                    /*
                    if (testFail.Count() == 0 && automationNameList.Count != 1)
                    {
                        queryResults3 = Query.And(
                                            Query.GT("Date", mDate),
                                            Query.EQ("test-results.@project-name", project),
                                                Query.ElemMatch("test-run.test-results.test-suite.results.test-case",
                                                    Query.And(
                                                        Query.EQ("@name", automation),
                                                        Query.EQ("@success", "False"))));
                        testFail = collection.Find(queryResults3);
                    }
                    if (testFail.Count() == 0 && automationNameList.Count == 1)
                    {

                        queryResults3 = Query.And(
                                            Query.GT("Date", mDate), 
                                            Query.EQ("test-results.@project-name", project),
                                                Query.And(
                                                    Query.EQ("test-results.test-suite.results.test-case.@name", automation),
                                                    Query.EQ("test-results.test-suite.results.test-case.@success", "False")));
                        testFail = collection.Find(queryResults3);
                    }
                     */
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
                            BsonDocument failTypeDoc = failCursor.First();
                            BsonDocument failures = failTypeDoc["failures"].AsBsonDocument;
                            BsonArray failAutomation = failures["automation"].AsBsonArray;
                            string failureType = string.Empty;
                            string failureMsg = string.Empty;
                            foreach (BsonDocument failAuto in failAutomation)
                            {
                                if (failAuto["@name"].AsString.Equals(automation) == true)
                                {
                                    BsonDocument failStatus = failAuto["status"].AsBsonDocument;
                                    failureType = failStatus["@failure-type"].AsString;
                                    failureMsg = failStatus["@message"].AsString;
                                }
                            }
                            BsonArray configs = testRun["Configuration"].AsBsonArray;
                            foreach (BsonDocument config in configs)
                            {
                                BsonArray testResults = config["test-results"].AsBsonArray;
                                string key = config["@templateName"].AsString;
                                foreach (BsonDocument testResult in testResults)
                                {
                                    if (testResult["@project-name"].Equals(project) == true)
                                    {
                                        BsonDocument testSuite = testResult["test-suite"].AsBsonDocument;
                                        BsonDocument results = testSuite["results"].AsBsonDocument;
                                        BsonArray testCase = testCase = results["test-case"].AsBsonArray;
                                        string errorMsg = string.Empty;

                                        foreach (BsonDocument test in testCase)
                                        {
                                            if (test["@success"].Equals("False") && test["@name"].Equals(automation))
                                            {
                                                if (failCursor.Count() == 0)
                                                {
                                                    failureType = "Failure";
                                                }
                                                /*
                                                BsonDocument failure = test["failure"].AsBsonDocument;
                                                errorMsg = failure["message"].AsBsonDocument["#cdata-section"].AsString;
                                                 */
                                                
                                                if (failConfigTable.ContainsKey(key) == false)
                                                {
                                                    Hashtable projectTable = new Hashtable();
                                                    ArrayList list = new ArrayList();
                                                    Hashtable detailTable = new Hashtable();
                                                    list.Add(failureType);
                                                    list.Add(version);
                                                    list.Add(errorMsg);
                                                    list.Add(failureMsg);
                                                    detailTable.Add(automation, list);
                                                    projectTable.Add(project, detailTable);
                                                    failConfigTable.Add(key, projectTable);
                                                }
                                                else
                                                {
                                                    Hashtable table = (Hashtable)failConfigTable[key];
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
                                                            list.Add(failureMsg);
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
                                                        list.Add(failureMsg);
                                                        errorTable.Add(automation, list);
                                                        table.Add(project, errorTable);
                                                    }
                                                    failConfigTable[key] = table;
                                                }
                                            }
                                        }
                                    }
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
                                BsonArray testResults = config["test-results"].AsBsonArray;
                                string key = config["@templateName"].AsString;
                                foreach (BsonDocument testResult in testResults)
                                {
                                    if (testResult["@project-name"].Equals(project) == true)
                                    {
                                        BsonDocument testSuite = testResult["test-suite"].AsBsonDocument;
                                        BsonDocument results = testSuite["results"].AsBsonDocument;
                                        BsonArray testCase = testCase = results["test-case"].AsBsonArray;

                                        foreach (BsonDocument test in testCase)
                                        {
                                            if (test["@success"].Equals("True") && test["@name"].Equals(automation))
                                            {
                                                
                                                if (successConfigTable.ContainsKey(key) == false)
                                                {
                                                    Hashtable projectTable = new Hashtable();
                                                    Hashtable detailTable = new Hashtable();
                                                    ArrayList list = new ArrayList();
                                                    list.Add(version);
                                                    detailTable.Add(automation, list);
                                                    projectTable.Add(project, detailTable);
                                                    successConfigTable.Add(key, projectTable);
                                                }
                                                else
                                                {
                                                    Hashtable table = (Hashtable)successConfigTable[key];
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
                                                    successConfigTable[key] = table;
                                                }
                                            }
                                        }
                                    }
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
                        BsonDocument failTypeDoc = failCursor.First();
                        BsonDocument failures = failTypeDoc["failures"].AsBsonDocument;
                        BsonArray failAutomation = failures["automation"].AsBsonArray;
                        string failureType = string.Empty;
                        string failureMsg = string.Empty;
                        foreach (BsonDocument failAuto in failAutomation)
                        {
                            if (failAuto["@name"].AsString.Equals(automation) == true)
                            {
                                BsonDocument failStatus = failAuto["status"].AsBsonDocument;
                                failureType = failStatus["@failure-type"].AsString;
                                failureMsg = failStatus["@message"].AsString;
                            }
                        }
                        string errorMsg = string.Empty;
                        foreach (BsonDocument fail in testFail)
                        {
                            BsonDocument testRun = fail["TestRun"].AsBsonDocument;
                            BsonArray configs = testRun["Configuration"].AsBsonArray;
                            foreach (BsonDocument config in configs)
                            {
                                BsonArray testResults = config["test-results"].AsBsonArray;
                                foreach (BsonDocument testResult in testResults)
                                {
                                    if (testResult["@project-name"].Equals(project) == true)
                                    {
                                        BsonDocument testSuite = testResult["test-suite"].AsBsonDocument;
                                        BsonDocument results = testSuite["results"].AsBsonDocument;
                                        BsonArray testCase = results["test-case"].AsBsonArray;
                                        /*
                                        foreach (BsonDocument test in testCase)
                                        {
                                            if (test["@success"].Equals("False") && test["@name"].Equals(automation))
                                            {
                                                BsonDocument failure = test["failure"].AsBsonDocument;
                                                errorMsg = failure["message"].AsBsonDocument["#cdata-section"].AsString;
                                            }
                                        }
                                        */
                                    }
                                }
                            }
                        }
                        if (failAllConfigTable.ContainsKey(project) == false)
                        {
                            ArrayList list = new ArrayList();
                            list.Add(failureType);
                            list.Add(version);
                            list.Add(errorMsg);
                            list.Add(failureMsg);
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
                            list.Add(failureMsg);
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
