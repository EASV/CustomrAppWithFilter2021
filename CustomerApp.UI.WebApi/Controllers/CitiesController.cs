using System;
using CustomerApp.Core.Domain;
using CustomerApp.Core.IServices;
using CustomerApp.Core.Models;
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
            try
            {
                return Ok(_cityService.ReadAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        
        [HttpGet("{zipCode}")]
        public IActionResult Get(int zipCode)
        {
            return Ok(_cityService.FindCityByZipcode(zipCode));
        }

        [HttpPut("{zipCode}")]
        public IActionResult Put(int zipCode, [FromBody] City city)
        {
            if (zipCode != city.ZipCode)
            {
                return BadRequest("ZipCodes need to match in both url and object");
            }
            try
            {
                return Ok(_cityService.Update(city));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
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