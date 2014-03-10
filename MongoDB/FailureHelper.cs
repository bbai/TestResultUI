using System;
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
    public class FailureHelper
    {
        public MongoCollection<BsonDocument> collection;
        private string mProjectName;
        private string mRuntimeVersion;
        private string mAutomationName;
        private string mSuccess;
        private string mFailureType;
        public FailureHelper(string serverAddr, string port, string dbName, string projectName, string runTimeVersion, string automationName, string success, string failureType)
        {
            MongoClient client = new MongoClient("mongodb://" + serverAddr + ":" + port);
            MongoServer server = client.GetServer();
            MongoDatabase mongoDB = server.GetDatabase(dbName);
            mProjectName = projectName;
            mRuntimeVersion = runTimeVersion;
            mAutomationName = automationName;
            mSuccess = success;
            mFailureType = failureType;
            collection = mongoDB.GetCollection("UnitTestFailures");
        }
        public string GetStatusMsg(string solutionName, string runtimeVersion, string automationName)
        {
            var query = Query.And(Query.EQ("@project-name", solutionName), Query.EQ("@runtime-version", runtimeVersion), Query.ElemMatch("failures.automation", Query.EQ("@name", automationName)));
            MongoCursor<BsonDocument> cursor = collection.Find(query);
            string statusMsg = string.Empty;
            foreach (BsonDocument doc in cursor)
            {
                BsonDocument failure = doc["failures"].AsBsonDocument;
                BsonArray automation = failure["automation"].AsBsonArray;
                foreach (BsonDocument unitTest in automation)
                {
                    if (unitTest["@name"].Equals(automationName) == true)
                    {
                        BsonDocument status = unitTest["status"].AsBsonDocument;
                        statusMsg = status["@message"].AsString;
                    }
                }
            }
            if (statusMsg.Equals(""))
            {
                statusMsg = "No status message.";
            }
            return statusMsg;
        }

        public bool ProcessFailure(string message)
        {
            var query = Query.And(Query.EQ("@project-name", mProjectName), Query.EQ("@runtime-version", mRuntimeVersion));
            MongoCursor<BsonDocument> cursor = collection.Find(query);

            BsonDocument project = GetProject(cursor, mProjectName, mRuntimeVersion);
            BsonDocument failure = new BsonDocument();
            if (cursor.Count() != 0)
            {
                failure = project["failures"].AsBsonDocument;
            }
            BsonArray array = new BsonArray();
            try
            {
                array = failure["automation"].AsBsonArray;
            }
            catch (KeyNotFoundException)
            {
                array = new BsonArray();
            }
            array = AddFailureDetails(array, mAutomationName, mSuccess, mFailureType, message);
            BsonDocument doc = new BsonDocument();
            doc.Add("automation", array);
            if (cursor.Count() == 0)
            {
                project.Add("failures", doc);
                collection.Insert(project);
            }
            else
            {
                var update = Update.Set("failures", doc);
                collection.Update(query, update);
            }
            return true;
        }

        public BsonDocument GetProject(MongoCursor<BsonDocument> cursor, string projectName, string runTimeVersion)
        {
            BsonDocument ret = new BsonDocument();
            if (cursor.Count() != 0)
            {
                ret = cursor.First();
            }
            else
            {
                ret.Add("@project-name", projectName);
                ret.Add("@runtime-version", runTimeVersion);
            }
            return ret;
        }

        public BsonArray AddFailureDetails(BsonArray automation, string automationName, string success, string failureType, string message)
        {
            BsonDocument doc = new BsonDocument
            {
                {"@name", automationName},
                {"@success", success},
                {"status", new BsonDocument{{"@failure-type", failureType}, {"@message", message}}}
            };
            BsonArray array = automation;
            array.Add(doc);
            return array;
        }
    }
}
