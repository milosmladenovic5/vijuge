using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace Vijuge.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string jsonString = JsonSerializer.Serialize("Welcome to Vijuge. Now fuck off, this is private API.");
            return StatusCode(200, jsonString);
        }
    }
}
