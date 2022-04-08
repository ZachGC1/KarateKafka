using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyKafkaProducer;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BomberController : ControllerBase
    {
        private readonly ILogger<BomberController> _logger;

        public BomberController(ILogger<BomberController> logger)
        {
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Bomb(string contents)
        {
            var producer = new MyKafkaProducer();

            await producer.Produce(contents);

            return this.Ok();
        }
    }
}
