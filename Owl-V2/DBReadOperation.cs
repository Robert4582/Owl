using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Owl_V2
{
    public class DBReadOperation : DBOperation
    {
        public void Connect()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");
        }

        public BsonDocument FindAllData()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");

           // BsonDocument documents = collection.Find(new BsonDocument()).ToBsonDocument();
            //collection.ToBsonDocument();
            //return collection.ToBsonDocument();

            var cursor = from PlayerData in collection.AsQueryable()
                         select PlayerData;
            BsonDocument doc = new BsonDocument();
            foreach (var document in cursor)
            {
                doc.AddRange(document);
            }

            return doc;

            /*
            foreach (BsonDocument doc in documents)
            {
                Console.WriteLine(doc.ToString());
            }
            */
        }

        public BsonDocument FindDataByFilterAndInt(string Filter, int Value)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");

            //var filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000);
            var filter = Builders<BsonDocument>.Filter.Eq(Filter, Value);
            var documents = collection.Find(filter).FirstOrDefault();

            return documents;
            //Console.WriteLine(documents.ToString());
        }

        public BsonDocument FindDataByFilterAndSting(string Filter, String Value)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");

            var filter = Builders<BsonDocument>.Filter.Eq(Filter, Value);
            var documents = collection.Find(filter).FirstOrDefault();
            
            return documents;
            //Console.WriteLine(documents.ToString());
        }
    }
}
