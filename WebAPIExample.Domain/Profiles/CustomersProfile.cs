using AutoMapper;
using WebAPIExample.Domain.Models;
using WebAPIExample.Models.Models;

namespace WebAPIExample.Domain.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<CustomerModel, CustomerDTO>();    
            CreateMap<CustomerDTO, CustomerModel>();
        }
    }
}
