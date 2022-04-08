using Microsoft.AspNetCore.Mvc;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly ProducerFactory _producerFactory;
        public ProducerController(ProducerFactory producerFactory)
        {
            _producerFactory = producerFactory;
        }

        [HttpGet(Name = "Produce")]
        public void Get(string message)
        {
            _producerFactory.Produce(message);
        }
    }
}
