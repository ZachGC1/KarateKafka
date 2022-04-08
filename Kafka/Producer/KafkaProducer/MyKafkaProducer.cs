using Confluent.Kafka;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace KafkaProducer
{
    public class MyKafkaProducer
    {
        public MyKafkaProducer() { }

        public async Task Produce(string content)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            var myId = Guid.NewGuid().ToString();

            using var p = new ProducerBuilder<string, string>(config).Build();
            var message = new Message<string, string>()
            {
                Key = myId,
                Value = content
            };

            var dr = await p.ProduceAsync("guid", message);
            Console.WriteLine($"Produced message on key {message.Key} to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");
        }
    }
}