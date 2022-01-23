using AutoMapper;
using System.Collections.Generic;
using WebAPIExample.Data.Transactions;
using WebAPIExample.Domain.Models;
using WebAPIExample.Models.Models;

namespace WebAPIExample.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            var customersFromRepo = _unitOfWork.Customers.GetAll();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customersFromRepo);
        }

        public CustomerDTO GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
            {
                return null;
            }

            return _mapper.Map<CustomerDTO>(customer);
        }

        public void Update(int id, CustomerDTO customer)
        {
            var customerModel = _mapper.Map<CustomerModel>(customer);
            customerModel.Id = id;

            _unitOfWork.Customers.Update(customerModel);
        }

        public CustomerModel PostCustomer(CustomerDTO customer)
        {
            var customerModel = _mapper.Map<CustomerModel>(customer);

            _unitOfWork.Customers.Add(customerModel);
            _unitOfWork.Commit();

            return customerModel;
        }

        public CustomerModel DeleteCustomer(int id)
        {
            var customerModel = _unitOfWork.Customers.Get(id);

            _unitOfWork.Customers.Remove(customerModel);
            _unitOfWork.Commit();

            return customerModel;
        }
    }
}
