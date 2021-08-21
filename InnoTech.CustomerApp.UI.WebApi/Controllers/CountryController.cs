using System;
using InnoTech.CustomerApp.Core.IServices;
using InnoTech.CustomerApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.CustomerApp.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_countryService.ReadAll());
        }
       
        [HttpPost]
        public IActionResult Post(Country country)
        {
            try
            {
                return Ok(_countryService.Create(country));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}