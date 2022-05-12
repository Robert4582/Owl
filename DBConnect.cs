using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Owl
{
    public class DBConnect
    {
        public void Connect()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
        }
    }
}
