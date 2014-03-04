using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using Mongo;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBHelper mongo = new MongoDBHelper("mongodb://10.0.3.26:27017/", "UnitTestDB", "UnitTestResults", 300);
            Console.WriteLine("Enter Days:");
            int days = Convert.ToInt32(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
