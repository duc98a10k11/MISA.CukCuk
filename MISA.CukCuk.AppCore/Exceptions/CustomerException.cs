using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.AppCore.Exceptions
{
    public class CustomerException:Exception
    {
        public CustomerException(string msg) : base(msg)
        {

        }

        public static void CheckCustomerCodeEmpty(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                var response = new
                {
                    devMsg = "Mã khách hàng không được phép để trống",
                    MISACode = "001"
                };
                throw new CustomerException("Mã khách hàng không được phép để trống.");
            }
        }
    }
}
