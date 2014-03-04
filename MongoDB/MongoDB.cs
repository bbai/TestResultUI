using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace Mongo
{
    public class MongoDBHelper
    {
        public MongoCollection<BsonDocument> collection;
        public Hashtable successAllConfigTable;
        public Hashtable failAllConfigTable;
        public Hashtable successConfigTable;
        public Hashtable failConfigTable;
        public string status;
        private DateTime mDate;
        public MongoDBHelper(string serverAddr, string dbName, string collectionName, int days)
        {
            MongoClient client = new MongoClient(serverAddr);
            MongoServer server = client.GetServer();
            MongoDatabase mongoDB = server.GetDatabase(dbName);
            collection = mongoDB.GetCollection(collectionName);
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
            MongoCursor<BsonDocument> cursor = collection.Find(dateQuery).SetSkip(1);
            int numTotalTests = 0;
            int numFailureTests = 0;
            int[] ret = new int[2];
            foreach (BsonDocument doc in cursor)
            {
                if (doc != null)
                {
                    BsonDocument testResults = doc["test-results"].AsBsonDocument;
                    numTotalTests += Convert.ToInt32(testResults["@total"].AsString);
                    numFailureTests += Convert.ToInt32(testResults["@failures"].AsString);
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
            var projectNames = collection.Distinct("test-results.@project-name").ToList();
            Hashtable projectAutomationTable = new Hashtable();
            foreach (string project in projectNames)
            {
                var query = Query.And(Query.GT("Date", mDate),Query.EQ("test-results.@project-name", project));
                MongoCursor<BsonDocument> testCursor = collection.Find(query).SetLimit(1);
                ArrayList automationNames = new ArrayList();
                foreach (BsonDocument doc in testCursor)
                {
                    BsonDocument testResult = doc["test-results"].AsBsonDocument;
                    if (Convert.ToInt32(testResult["@total"]) == 0)
                    {
                        break;
                    }
                    BsonDocument testSuite = testResult["test-suite"].AsBsonDocument;
                    BsonDocument results = testSuite["results"].AsBsonDocument;
                    BsonArray testCase = new BsonArray();
                    try
                    {
                        testCase = results["test-case"].AsBsonArray;
                    }
                    catch (InvalidCastException)
                    {
                        testCase.Add(results["test-case"].AsBsonDocument);
                    }
                    foreach (BsonDocument caseResult in testCase)
                    {
                        automationNames.Add(caseResult["@name"].AsString);
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
            var projectNames = collection.Distinct("test-results.@project-name").ToList();
            Hashtable projectAutomationTable = this.GetProjectAutomationTable();
            foreach (string project in projectNames)
            {
                ArrayList automationNameList = (ArrayList)projectAutomationTable[project];
                Console.WriteLine(project);
                foreach (string automaion in automationNameList)
                {
                    var queryResults1 = Query.And(Query.GT("Date", mDate), Query.EQ("test-results.@project-name", project),
                                        Query.ElemMatch("test-results.test-suite.results.test-case",
                                        Query.And(Query.EQ("@name", automaion),
                                        Query.EQ("@success", "True"))));
                    MongoCursor<BsonDocument> testSuccess = collection.Find(queryResults1);
                    if (testSuccess.Count() == 0 && automationNameList.Count == 1)
                    {
                        queryResults1 = Query.And(Query.GT("Date", mDate), Query.EQ("test-results.@project-name", project),
                                        Query.And((Query.EQ("test-results.test-suite.results.test-case.@name", automaion)),
                                        Query.EQ("test-results.test-suite.results.test-case.@success", "True")));
                        testSuccess = collection.Find(queryResults1);
                    }
                    var queryResults2 = Query.And(Query.GT("Date", mDate), Query.EQ("test-results.@project-name", project),
                                        Query.ElemMatch("test-results.test-suite.results.test-case",
                                        Query.EQ("@name", automaion)));
                    MongoCursor<BsonDocument> testAll = collection.Find(queryResults2);
                    if (testAll.Count() == 0 && automationNameList.Count == 1)
                    {
                        queryResults2 = Query.And(Query.GT("Date", mDate), Query.EQ("test-results.@project-name", project),
                                        Query.And(Query.EQ("test-results.test-suite.results.test-case.@name", automaion)));
                        testAll = collection.Find(queryResults2);
                    }
                    var queryResults3 = Query.And(Query.GT("Date", mDate), Query.EQ("test-results.@project-name", project),
                                        Query.ElemMatch("test-results.test-suite.results.test-case",
                                        Query.And(Query.EQ("@name", automaion),
                                        Query.EQ("@success", "False"))));
                    MongoCursor<BsonDocument> testFail = collection.Find(queryResults3);
                    if (testFail.Count() == 0 && automationNameList.Count == 1)
                    {
                        queryResults3 = Query.And(Query.GT("Date", mDate), Query.EQ("test-results.@project-name", project),
                                        Query.And((Query.EQ("test-results.test-suite.results.test-case.@name", automaion)),
                                        Query.EQ("test-results.test-suite.results.test-case.@success", "False")));
                        testFail = collection.Find(queryResults3);
                    }
                    if (testSuccess.Count() != testAll.Count() && testSuccess.Count() != 0)
                    {
                        IEnumerable<BsonDocument> diffs = testAll.Except(testSuccess);
                        foreach (BsonDocument diffBson in diffs)
                        {
                            BsonDocument testResults = diffBson["test-results"].AsBsonDocument;
                            string key = testResults["@template-name"].AsString;
                            if (failConfigTable.ContainsKey(key) == false)
                            {
                                Hashtable projectTable = new Hashtable();
                                HashSet<string> list = new HashSet<string>();
                                list.Add(automaion);
                                projectTable.Add(project, list);
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
                                    HashSet<string> list = (HashSet<string>)table[project];
                                    if (list.Contains(automaion) == false)
                                        list.Add(automaion);
                                    table[project] = list;
                                }
                                else
                                {
                                    HashSet<string> list = new HashSet<string>();
                                    if (list.Contains(automaion) == false)
                                        list.Add(automaion);
                                    table.Add(project, list);
                                }
                                failConfigTable[key] = table;
                            }
                        }
                    }
                    if (testAll.Count() != testFail.Count() && testFail.Count() != 0)
                    {
                        IEnumerable<BsonDocument> diff = testAll.Except(testFail);
                        foreach (BsonDocument diffBson in diff)
                        {
                            BsonDocument testResults = diffBson["test-results"].AsBsonDocument;
                            string key = testResults["@template-name"].AsString;
                            if (successConfigTable.ContainsKey(key) == false)
                            {
                                Hashtable projectTable = new Hashtable();
                                HashSet<string> list = new HashSet<string>();
                                list.Add(automaion);
                                projectTable.Add(project, list);
                                successConfigTable.Add(key, projectTable);
                            }
                            else
                            {
                                Hashtable table = (Hashtable)successConfigTable[key];
                                if (table == null)
                                {
                                    table = new Hashtable();
                                }
                                if (table.ContainsKey(project))
                                {
                                    HashSet<string> list = (HashSet<string>)table[project];
                                    if (list.Contains(automaion) == false)
                                        list.Add(automaion);
                                    table[project] = list;
                                }
                                else
                                {
                                    HashSet<string> list = new HashSet<string>();
                                    if (list.Contains(automaion) == false)
                                        list.Add(automaion);
                                    table.Add(project, list);
                                }
                                successConfigTable[key] = table;
                            }
                        }
                    }
                    if (testFail.Count() == 0)
                    {

                        if (successAllConfigTable.ContainsKey(project) == false)
                        {
                            ArrayList list = new ArrayList();
                            list.Add(automaion);
                            successAllConfigTable.Add(project, list);
                        }
                        else
                        {
                            ArrayList list = (ArrayList)successAllConfigTable[project];
                            list.Add(automaion);
                            successAllConfigTable[project] = list;
                        }
                    }

                    if (testSuccess.Count() == 0)
                    {
                        if (failAllConfigTable.ContainsKey(project) == false)
                        {
                            ArrayList list = new ArrayList();
                            list.Add(automaion);
                            failAllConfigTable.Add(project, list);
                        }
                        else
                        {
                            ArrayList list = (ArrayList)failAllConfigTable[project];
                            list.Add(automaion);
                            failAllConfigTable[project] = list;
                        }
                    }
                }
            }
            ret = true;
            return ret;
        }
    }
}
