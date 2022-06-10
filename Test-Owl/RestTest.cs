using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Owl_V2;
using Owl_V2.Controllers;
using MongoDB.Bson;
using System.Reflection;
using System.Linq;

namespace Test_Owl
{
    public class RestTest
    {
        DBController dBController;

        [SetUp]
        public void SetUp()
        {
            dBController = new DBController();
        }

        [Test]
        public void FindsGetAndGetAll()
        {
            BsonArray array = (BsonArray)dBController.GetMethods()["methods"];
            var tester = array.Select(x => x["method name"].AsString);
            bool containsAll = new List<string> { "Get", "GetAll" }.All(s => tester.Contains(s));
            Assert.IsTrue(containsAll);
        }

        [Test]
        public void FindsGetParams()
        {
            BsonArray array = (BsonArray)dBController.GetMethods()["methods"];
            var tester = array.Select(x => x["parameters"]);
            bool containsParameters = tester.Contains(new BsonArray { "String", "Int32" });
            Assert.IsTrue(containsParameters);
        }
    }
}
