using MISA.CukCuk.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.AppCore.Interfaces.Service
{
    /// <summary>
    /// Service phục vụ cho đối tượng khách hàng
    /// </summary>
    /// CreatedBy: LMDuc (20/04/2021)
    public interface ICustomerService
    {
        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LMDuc (20/04/2021)
        public IEnumerable<Customer> GetAll();

        /// <summary>
        /// Lấy dữ liệu khách hàng theo id
        /// </summary>
        /// <param name="customerId">id của khác hàng</param>
        /// <returns>Dữ liệu của khách hàng theo id</returns>
        /// CreatedBy: LMDuc (20/04/2021)
        public Customer GetCustomerById(Guid customerId);
        
        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: LMDuc (20/04/2021)
        public int Insert(Customer customer);
        
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin cập nhật của khách hàng</param>
        /// <returns>số bản ghi được chỉnh sửa</returns>
        /// CreatedBy: LMDuc (20/04/2021)
        public int Update(Customer customer);
       
        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">id khách hàng cần xóa</param>
        /// <returns>số bản ghi đã xóa</returns>
        /// CreatedBy: LMDuc (20/04/20210)
        public int Delete(Guid customerId);
        
        /// <summary>
        /// Kiểm tra trùng thông tin mã khách hàng 
        /// </summary>
        /// <param name="customerCode">mã khách hàng</param>
        /// <returns>
        /// true - mã khách hàng bị trùng
        /// false - mã khách hàng không bị trùng
        /// </returns>
        /// CreateBy: LMDuc (20/04/2021)
        public bool CheckCustomerCodeExists(string customerCode);
        
    }
}
