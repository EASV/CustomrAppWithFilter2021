using System;
using System.Collections.Generic;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult<List<Address>> Get([FromQuery] Filter filter)
        {
            return Ok(_addressService.GetAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_addressService.GetById(id));
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Address address)
        {
            if (id != address.Id)
            {
                return BadRequest("IDs must match");
            }

            try
            {
                return Ok(_addressService.Update(address));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        
        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult<Address> Post([FromBody] Address address)
        {
            return Ok(_addressService.Create(address));
        }
    }
}