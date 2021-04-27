using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        protected override void Validate(Customer entity)
        {
            if (entity is Customer)
            {
                var customer = entity as Customer;
                // validate dữ liệu:
                // - check các thông tin bắt buộc nhập:
                CustomerException.CheckCustomerCodeEmpty(customer.CustomerCode);
                // check trùng mã: 
                var isExist = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode);
                if (isExist == true)
                {
                    throw new CustomerException("Mã khách hàng đã tồn tại trên hệ thống!");
                }
            }
        }
    }
}
