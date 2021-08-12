using System;
using System.Collections.Generic;
using CustomerApp.Core.Filter;
using CustomerApp.Core.IServices;
using CustomerApp.Core.Models;
using CustomerApp.UI.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApp.UI.WebApi.Controllers
{
    // https//:servername/api/customers
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult<FilteredList<CustomerDto>> Get([FromQuery] Filter filter)
        {
            try
            {
                var filteredList = _customerService.GetAllCustomers(filter);
                var list = filteredList.List;
                var listDTO = new List<CustomerDto>();
                foreach (var customer in list)
                {
                    listDTO.Add(new CustomerDto()
                    {
                        Id = customer.Id,
                        Address = $"Street: {customer.Address?.StreetName}",
                        FirstName = customer.FirstName
                    });
                }
                var newFitleredList = new FilteredList<CustomerDto>();
                newFitleredList.List = listDTO;
                newFitleredList.FilterUsed = filteredList.FilterUsed;
                newFitleredList.TotalCount = filteredList.TotalCount;
                return Ok(_customerService.GetAllCustomers(filter));
            }
            catch (NullReferenceException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customerService.FindCustomerById(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            try
            {
                return _customerService.CreateCustomer(customer);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message + "****\n"+e.StackTrace);
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
