using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "192.168.10.189",
    Port = Protocols.DefaultProtocol.DefaultPort,
    UserName = "guest",
    Password = "guest",
    //VirtualHost = "/",
    ContinuationTimeout = new TimeSpan(10, 0, 0, 0)
};

using (var connection = factory.CreateConnection())
{

    try
    {
        using (var channel = connection.CreateModel())
        {
            //channel.QueueDeclare(queue: "KarateMove",
            //                     durable: true,
            //                     exclusive: false,
            //                     autoDelete: false,
            //                     arguments: null);

            string message = "KarateChopie";

            var body = Encoding.UTF8.GetBytes(message);

            var test = channel.NextPublishSeqNo;
            channel.BasicPublish(exchange: "",
                                 routingKey: "KarateMove",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine(" [x] Sent {0}", message);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("#############################", ex);
    }
}
