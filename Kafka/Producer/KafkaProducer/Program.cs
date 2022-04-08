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
            var producer = new MyKafkaProducer();

            var content = GetResourceFile($"{typeof(Program).Namespace}.Resources.request.json");

            while (true)
            {
                await producer.Produce(content);

                // Thread.Sleep(1000);
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