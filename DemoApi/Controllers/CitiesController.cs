using DemoApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DemoApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("")]
    public class CitiesController: ControllerBase
    {
        private readonly DemoDbContext demoDb;

        public CitiesController(DemoDbContext demoDb)
        {
            this.demoDb = demoDb;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this.demoDb.City.ToList());
        }
    }
}
