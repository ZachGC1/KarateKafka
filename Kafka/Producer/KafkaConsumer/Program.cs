using Confluent.Kafka;
using System;
using System.Threading;
using BombSquad.Models;
using Newtonsoft.Json;

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
                while (true)
                {
                    try
                    {


                        var cr = c.Consume(cts.Token);
                        var msg = cr.Message;

                        var move = JsonConvert.DeserializeObject<UserMove>(msg.Value);

                        Console.WriteLine($"lv.{move.User.Level} user {move.User.Name} used {move.User.Weapon} to execute {move.Move.Name} at power {move.Move.Level}!");
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid message!");
                    }
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