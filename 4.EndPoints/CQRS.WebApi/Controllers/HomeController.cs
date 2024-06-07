using Microsoft.AspNetCore.Mvc;

namespace CQRS.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        public IEnumerable<string> Get()
        {
            return Enumerable.Range(1, 5).Select(index => $"{index}").ToArray();
        }
    }
}
