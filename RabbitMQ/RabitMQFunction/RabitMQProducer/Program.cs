using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { 
    HostName = "192.168.10.189",
    Port = Protocols.DefaultProtocol.DefaultPort,
    UserName = "guest",
    Password = "guest",
    VirtualHost = "/",
  ContinuationTimeout = new TimeSpan(10, 0, 0, 0)
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "KarateMove",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    string message = "Chopie";
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "",
                         routingKey: "hello",
                         basicProperties: null,
                         body: body);
    Console.WriteLine(" [x] Sent {0}", message);
}