using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KafkaMoves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        string myId = Guid.NewGuid().ToString();

        [HttpPost]
        public async Task<string> UserMove(string move)
        {
            using var p = new ProducerBuilder<string, string>(config).Build();
            {
                var message = new Message<string, string>()
                {
                    Key = myId,
                    Value = move
                };

                var dr = await p.ProduceAsync("guid", message);
                return $"Produced message on key {message.Key} to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}";
            }
        }
    }
}
