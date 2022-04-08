using Confluent.Kafka;
using System;
using System.Threading;

namespace KafkaConsumer
{
    class Program
    {
        static void Main()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var c = new ConsumerBuilder<string, string>(conf).Build();
            c.Subscribe("guid");

            // Because Consume is a blocking call, we want to capture Ctrl+C and use a cancellation token to get out of our while loop and close the consumer gracefully.
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                ulong i = 0;

                while (true)
                {
                    var cr = c.Consume(cts.Token);
                    var msg = cr.Message;

                    Console.WriteLine($"Consumed message {i++}-{msg.Key} from topic {cr.Topic}, partition {cr.Partition}, offset {cr.Offset}");

                    // Do something interesting with the message
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                c.Close();
            }
        }

    }
}