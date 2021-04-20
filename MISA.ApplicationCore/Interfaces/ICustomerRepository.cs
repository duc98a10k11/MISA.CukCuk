using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer GetAll();
        public Customer GetCustomerById(Guid customerId);
        public int AddCustomer(Customer customer);
        public int EditCustomer(Customer customer, Guid customerId);

        public int DeleteCustomerById(Guid customerId);

     }
}
