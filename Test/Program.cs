using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using MongoDB;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBHelper mongo = new MongoDBHelper("mongodb://10.0.3.26:27017/", "UnitTestDB", "UnitTestResults");
            Console.WriteLine("Enter Days:");
            int days = Convert.ToInt32(Console.ReadLine());
            MongoCursor<BsonDocument> cursor = mongo.GetCursorinDays(days);
            int[] result = mongo.GetNumTotalAndFail(cursor);
            Console.WriteLine("Total: " + result[0]);
            Console.WriteLine("Fail: " + result[1]);
            Console.ReadKey();
        }
    }
}
