using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface Khách hàng
    /// </summary>
    /// CreateBY: LMDuc (27/04/2021)
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// kiểm tra mã khách hàng đã tồn tại
        /// </summary>
        /// <param name="customerCode">mã khách hàng</param>
        /// <returns>
        /// true - mã khách hàng đã tồn tại
        /// false - mã khách hàng chưa có trong hệ thống
        /// </returns>
        /// CreatedBY: LMDuc(27/04/2021)
        public bool CheckCustomerCodeExist(string customerCode);
        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại
        /// </summary>
        /// <param name="phonNumber">số điện thoại</param>
        /// <returns>
        /// true - mã khách hàng đã tồn tại
        /// false - mã khách hàng chưa có trong hệ thống
        /// </returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public bool CheckPhoneNumberExist(string phonNumber);
    }
}
