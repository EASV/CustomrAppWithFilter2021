using System;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
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
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_cityService.ReadAll());
        }
        
        [HttpGet("{zipCode}")]
        public IActionResult Get(int zipCode)
        {
            return Ok(_cityService.FindCityByZipcode(zipCode));
        }

        [HttpPost]
        public IActionResult Post(City city)
        {
            try
            {
                return Ok(_cityService.Create(city));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        // 'https://localhost:5001/api/cities/1'
        [HttpDelete("{zipCode}")]
        public IActionResult Delete(int zipCode)
        {
            try
            {
                return Ok(_cityService.Delete(zipCode));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}