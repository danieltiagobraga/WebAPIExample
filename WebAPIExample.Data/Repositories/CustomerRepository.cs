using WebAPIExample.Data.Data;
using WebAPIExample.Data.Repositories.Base;
using WebAPIExample.Models.Models;

namespace WebAPIExample.Data.Repositories
{
    public class CustomerRepository : Repository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {

        }
    }
}
