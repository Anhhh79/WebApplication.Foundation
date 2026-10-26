using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        // GET: api/system/ping
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            var result = Ok(new
            {
                message = "Foundation API is running"
            });

            return result;
        }
    }
}
