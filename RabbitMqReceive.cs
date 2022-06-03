using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Owl
{
    public class RabbitMqReceive
    {
        private ConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel channel;

        public RabbitMqReceive()
        {
            connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
        }

        public bool Receive()
        {
            channel.QueueDeclare(queue: "DataPack",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            channel.BasicConsume(queue: "DataPack",
                                    autoAck: true,
                                    consumer: consumer);

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();

            return true;
            
        }
    }
}
