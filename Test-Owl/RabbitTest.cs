using NUnit.Framework;
using Owl_V2;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Test_Owl
{
    public class RabbitTest
    {
        
        [SetUp]
        public void Setup() 
        {
            var factory = new ConnectionFactory() { HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "DataPack",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "DataPack",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

        [Test]
        public void TestRabbit()
        {
            //Arrange
            RabbitMQReceive RabbitMq = new RabbitMQReceive();

            //Act
            RabbitMq.Receive();

            //Assert
            Assert.IsTrue(RabbitMq.Receive());
        }

        [TearDown]
        public void TearDown() { }

    }
}
