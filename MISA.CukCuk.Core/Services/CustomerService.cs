using MISA.CukCuk.Core.AttributeCustom;
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
    /// <summary>
    /// Dịch vụ khách hàng
    /// </summary>
    /// CreatedBy: LMDuc (27/04/2021)
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">dữ liệu cần validate</param>
        /// CreatedBy: LMDuc(27/04/2021)
        protected override void CustomValidate(Customer entity)
        {

               
            
        }
    }
}
