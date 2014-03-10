﻿using System;
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
        public FailureHelper(string serverAddr, string dbName)
        {
            MongoClient client = new MongoClient("mongodb://" + serverAddr);
            MongoServer server = client.GetServer();
            MongoDatabase mongoDB = server.GetDatabase(dbName);
            collection = mongoDB.GetCollection("UnitTestFailures");
        }
        public bool ProcessFailure(string projectName, string runTimeVersion, string automationName, string success, string failureType, string message)
        {
            var query = Query.And(Query.EQ("@project-name", projectName), Query.EQ("@runtime-version", runTimeVersion));
            MongoCursor<BsonDocument> cursor = collection.Find(query);

            BsonDocument project = GetProject(cursor, projectName, runTimeVersion);
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
            array = AddFailureDetails(array, automationName, success, failureType, message);
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