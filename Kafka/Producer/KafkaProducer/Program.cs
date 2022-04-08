using Confluent.Kafka;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace KafkaProducer
{
    class Program
    {
        public static async Task Main()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            var myId = Guid.NewGuid().ToString();

            var content = GetResourceFile($"{typeof(Program).Namespace}.Resources.request.json");

            using var p = new ProducerBuilder<string, string>(config).Build();

            while (true)
            {
                var message = new Message<string, string>()
                {
                    Key = myId,
                    Value = content
                };

                var dr = await p.ProduceAsync("guid", message);
                Console.WriteLine($"Produced message on key {message.Key} to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");

                //Thread.Sleep(500);
            }
        }


        public static string GetResourceFile(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var s = assembly.GetManifestResourceStream(resourceName);
            using (var textStreamReader = new StreamReader(s))
            {
                var result = textStreamReader.ReadToEnd();
                return result;
            }
        }

    }
}