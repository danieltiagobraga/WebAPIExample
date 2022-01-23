using System.Collections.Generic;
using WebAPIExample.Domain.Models;
using WebAPIExample.Models.Models;

namespace WebAPIExample.Services.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetCustomers();
        CustomerDTO GetCustomer(int id);
        void Update(int id, CustomerDTO customer);
        CustomerModel PostCustomer(CustomerDTO customer);
        CustomerModel DeleteCustomer(int id);
    }
}