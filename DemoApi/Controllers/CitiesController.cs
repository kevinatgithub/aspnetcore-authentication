using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("")]
    public class CitiesController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Test");
        }
    }
}
