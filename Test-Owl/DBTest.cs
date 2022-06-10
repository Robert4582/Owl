using MongoDB.Bson;
using NUnit.Framework;
using Owl_V2;

namespace Test_Owl
{
    public class DBTest
    {
        [SetUp]
        public void Setup()
        {
            DBWriteOperation dB = new DBWriteOperation();
            dB.Connect();
            DBReadOperation read = new DBReadOperation();
            read.Connect();
        }

        [Test]
        public void Test1()
        {
            //Arrange
            BsonDocument document = new BsonDocument { { "student_id", 10000 }, {
                "scores",
                new BsonArray {
                new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                }
                }, { "class_id", 480 }};

            DBWriteOperation dB = new DBWriteOperation();
            DBReadOperation read = new DBReadOperation();

            //Act
            dB.InsetData(document);
            BsonDocument test = read.FindDataByFilterAndInt("student_id", 10000);

            //Assert
            Assert.AreEqual(test.ToString(), document.ToString());
        }

        [Test]
        public void CanDelete()
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

            DBWriteOperation dB = new DBWriteOperation();
            DBReadOperation read = new DBReadOperation();

            dB.InsetData(document);
            dB.DeleteData();

            Assert.AreEqual(new BsonDocument().ToString(), read.FindAllData().ToString());
        }

        [TearDown]
        public void TearDown()
        {
            DBWriteOperation dB = new DBWriteOperation();
            dB.DeleteData();
        }
    }
}