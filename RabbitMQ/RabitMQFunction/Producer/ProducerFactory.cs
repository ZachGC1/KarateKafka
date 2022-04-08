using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    public class ProducerFactory
    {
        private readonly ConnectionFactory _factory;
        private IModel _channel;

        public ProducerFactory()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "192.168.10.189",
                Port = Protocols.DefaultProtocol.DefaultPort,
                UserName = "guest",
                Password = "guest",
                ContinuationTimeout = new TimeSpan(10, 0, 0, 0)
            };

            var connection = _factory.CreateConnection();

            _channel = connection.CreateModel();
                    //channel.QueueDeclare(queue: "KarateMove",
                    //                     durable: true,
                    //                     exclusive: false,
                    //                     autoDelete: false,
        }

        public void Produce(string message) 
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                 routingKey: "KarateMove",
                                 basicProperties: null,
                                 body: body);
        }
    }
}

