using Confluent.Kafka;
using System;
using System.Threading;

namespace KafkaConsumer
{
    class Program
    {
        static void Main()
        {
            var consumer = new MyKafkaConsumer();
            consumer.Consume();
        }

    }
}