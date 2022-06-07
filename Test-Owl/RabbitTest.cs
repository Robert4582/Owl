﻿using NUnit.Framework;
using Owl;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Test_Owl
{
    public class RabbitTest
    {
        public void Rabbit()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
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

        [SetUp]
        public void Setup() { }

        [Test]
        public void TestRabbit()
        {
            //Arrange
            RabbitMqReceive RabbitMq = new RabbitMqReceive();
            Rabbit();

            //Act
            RabbitMq.Receive();

            //Assert
            Assert.IsTrue(RabbitMq.Receive());
        }

        [TearDown]
        public void TearDown() { }

    }
}