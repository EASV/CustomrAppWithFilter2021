using CustomerApp.Core.ApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.UI.WebApi.Controllers
{
    // https//:servername/api/customers
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_cityService.ReadAll());
        }
    }
}