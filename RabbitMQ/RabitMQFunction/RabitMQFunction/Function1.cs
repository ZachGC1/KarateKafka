using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace RabitMQFunction
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([RabbitMQTrigger("KarateMove", ConnectionStringSetting = "amqp://192.168.10.189:5672")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
