using Microsoft.EntityFrameworkCore;
using WebAPIExample.Models.Models;

namespace WebAPIExample.Data.Data
{
    public class DataContext : DbContext
    {
        /* PUT YOUR MODELS HERE*/
        public virtual DbSet<CustomerModel> Customers { get; set; }
        /* PUT YOUR MODELS HERE*/

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
