using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace MongoDB
{
    public class MongoDBHelper
    {
        public MongoCollection<BsonDocument> collection;
        public MongoDBHelper(string serverAddr, string dbName, string collectionName)
        {
            MongoClient client = new MongoClient(serverAddr);
            MongoServer server = client.GetServer();
            MongoDatabase mongoDB = server.GetDatabase(dbName);
            collection = mongoDB.GetCollection(collectionName);
        }

        public MongoCursor<BsonDocument> getCursorinDays(int days)
        {
            DateTime date = DateTime.Now.Subtract(TimeSpan.FromDays(days));
            var query = Query.And(Query.GT("Date", date));
            return collection.Find(query).SetSkip(1);
        }

        public int[] getNumTotalAndFail(MongoCursor<BsonDocument> cursor)
        {
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

    }
}
