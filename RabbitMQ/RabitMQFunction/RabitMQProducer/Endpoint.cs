using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace src.Microservice.Api.Controllers
{
    [Route("")]
    public class Endpoint : Controller
    {
        public Endpoint()
        {
                
        }

        [HttpGet]
        public IActionResult Get() 
        {
            
        }

    }
}