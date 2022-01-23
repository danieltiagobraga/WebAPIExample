using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models.Models
{
    [Table("TbCustomers")]
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}