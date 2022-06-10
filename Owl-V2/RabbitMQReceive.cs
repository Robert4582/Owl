using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Owl_V2
{
    public class RabbitMQReceive
    {
        private ConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel channel;

        public RabbitMQReceive()
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
