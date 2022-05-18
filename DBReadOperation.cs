using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Owl
{
    public class DBReadOperation : DBOperation
    {
        public void Connect()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");
        }

        public void FindAllData()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");

            var documents = collection.Find(new BsonDocument()).ToList();

            foreach (BsonDocument doc in documents)
            {
                Console.WriteLine(doc.ToString());
            }
        }

        public void FindDataByFilterAndInt(string Filter, int Value)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");

            //var filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000);
            var filter = Builders<BsonDocument>.Filter.Eq(Filter, Value);
            var documents = collection.Find(filter).FirstOrDefault();

            Console.WriteLine(documents.ToString());
        }

        public void FindDataByFilterAndSting(string Filter, String Value)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");

            var filter = Builders<BsonDocument>.Filter.Eq(Filter, Value);
            var documents = collection.Find(filter).FirstOrDefault();

            Console.WriteLine(documents.ToString());
        }
    }
}
