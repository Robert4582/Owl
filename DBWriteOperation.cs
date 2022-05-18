using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Owl
{
    public class DBWriteOperation : DBOperation
    {
        BsonDocument document = new BsonDocument { { "student_id", 10000 }, {
                "scores",
                new BsonArray {
                new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                }
                }, { "class_id", 480 }};

        public void Connect()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");

            //collection.InsertOne(document);
        }

        public void InsetData(BsonDocument document)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("PB-Funday");
            var collection = database.GetCollection<BsonDocument>("PlayerData");

            collection.InsertOne(document);
        }
    }
}
