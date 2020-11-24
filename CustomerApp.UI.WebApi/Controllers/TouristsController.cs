using System;
using CustomerApp.Core.ApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.UI.WebApi.Controllers
{
    // https//:servername/api/customers
    [Route("api/[controller]")]
    [ApiController]
    public class TouristsController : ControllerBase
    {
        private ITouristService _touristService;

        public TouristsController(ITouristService touristService)
        {
            _touristService = touristService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(_touristService.ReadAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}