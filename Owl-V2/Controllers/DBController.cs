using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Owl_V2.Controllers
{
    public class DBController : Controller
    {
        [HttpGet]
        public BsonDocument GetMethods()
        {
            var methodData = typeof(DBController).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(x => x.Name != nameof(GetMethods) && x.ReturnType == typeof(BsonDocument));
            BsonDocument document = new BsonDocument();
            BsonArray array = new BsonArray();
            foreach (var item in methodData)
            {
                var innerDoc = new BsonDocument();
                Dictionary<string, object> keys = new Dictionary<string, object>();
                keys.Add("method name", item.Name);
                keys.Add("parameters", item.GetParameters().Select(x => x.ParameterType.Name));
                keys.Add("returnType", item.ReturnType.Name);
                innerDoc.AddRange(keys);
                array.Add(innerDoc);
            }
            document.Add("methods", array);
            return document;
        }

        [HttpGet]
        public BsonDocument Get(string name, int value) 
        {
            DBReadOperation dBRead = new DBReadOperation();

            return dBRead.FindDataByFilterAndInt(name, value);
        }

        [HttpGet]
        public BsonDocument GetAll() 
        {
            DBReadOperation dBRead = new DBReadOperation();

            return dBRead.FindAllData();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
