using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Exceptions
{
    /// <summary>
    /// Exception Customer
    /// </summary>
    /// CreatedBY: LMDuc (27/04/2021)
    public class CustomerException : Exception
    {
        public CustomerException(string msg) : base(msg)
        {

        }

        /// <summary>
        /// bắt lỗi mã khách hàng để trống
        /// </summary>
        /// <param name="customerCode">mã khách hàng</param>
        /// CreatedBY: LMDuc (27/04/2021)
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
