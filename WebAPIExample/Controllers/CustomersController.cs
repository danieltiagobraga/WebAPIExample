using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIExample.Domain.Models;
using WebAPIExample.Models.Models;
using WebAPIExample.Services.Services;

namespace WebAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<CustomerDTO>> GetCustomers() => Ok(_customerService.GetCustomers());

        // GET: api/Customers/5
        [HttpGet("{id}")]
        [Produces("application/json", "application/xml")]
        public ActionResult<CustomerDTO> GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);

            return (customer is null) ? NotFound() : Ok(customer);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, CustomerDTO customer)
        {
            if (!CustomerExists(id))
            {
                return NotFound();
            }

            _customerService.Update(id, customer);

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        [Consumes("application/json")]                      // ONLY CONSUMES APPLICATION/JSON
        [Produces("application/json", "application/xml")]   // ONLY PRODUCES APPLICATION/JON AND APPLICATION/XML
        public ActionResult<CustomerDTO> PostCustomer(CustomerDTO customer)
        {
            var customerModel = _customerService.PostCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = customerModel.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<CustomerModel> DeleteCustomer(int id)
        {
            if (!CustomerExists(id))
            {
                return NotFound();
            }

            _ = _customerService.DeleteCustomer(id);
            return NoContent();
        }

        private bool CustomerExists(int id) => _customerService.GetCustomer(id) != null;
    }
}