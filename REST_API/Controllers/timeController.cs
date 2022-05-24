using Microsoft.AspNetCore.Mvc;

using REST_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        static TimeRepository timeRepository = new TimeRepository();

        [HttpGet]
        public DateTime Get()
        {
            return timeRepository.ShowTime();
        }

        
    }
}
