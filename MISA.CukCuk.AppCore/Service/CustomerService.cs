using MISA.CukCuk.AppCore.Entities;
using MISA.CukCuk.AppCore.Exceptions;
using MISA.CukCuk.AppCore.Interfaces.Repository;
using MISA.CukCuk.AppCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.AppCore.Service
{
    /// <summary>
    /// Service phục vụ cho đối tượng khách hàng
    /// </summary>
    /// CreateBy: LMDuc (20/04/2021)
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Khai báo để sử dụng ICusomerRepository
        /// </summary>
        ICustomerRepository _customerRepository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="customerRepository"></param>
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Kiểm tra trùng thông tin mã khách hàng 
        /// </summary>
        /// <param name="customerCode">mã khách hàng</param>
        /// <returns>
        /// true - mã khách hàng bị trùng
        /// false - mã khách hàng không bị trùng
        /// </returns>
        /// CreateBy: LMDuc (20/04/2021)
        public bool CheckCustomerCodeExists(string customerCode)
        {
            var check = _customerRepository.CheckCustomerCodeExists(customerCode);
            return check;
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">id khách hàng cần xóa</param>
        /// <returns>số bản ghi đã xóa</returns>
        /// CreatedBy: LMDuc (20/04/20210)
        public int Delete(Guid customerId)
        {
            var rowAffect = _customerRepository.Delete(customerId);
            return rowAffect;
        }

        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LMDuc (20/04/2021)
        public IEnumerable<Customer> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        /// <summary>
        /// Lấy dữ liệu khách hàng theo id
        /// </summary>
        /// <param name="customerId">id của khác hàng</param>
        /// <returns>Dữ liệu của khách hàng theo id</returns>
        /// CreatedBy: LMDuc (20/04/2021)
        public Customer GetCustomerById(Guid customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            return customer;
        }

        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: LMDuc (20/04/2021)
        public int Insert(Customer customer)
        {
            //// Validate dữ liệu:
            ////- check các thông tin bắt buộc nhập
            CustomerException.CheckCustomerCodeEmpty(customer.CustomerCode);
            //// - check mã có trùng hay không?
            if (CheckCustomerCodeExists(customer.CustomerCode))
            {
                throw new CustomerException("MÃ khách hàng đã tồn tại trên hệ thống.");
               
            }
            
            var rowAffect = _customerRepository.Insert(customer);
            return rowAffect;
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin cập nhật của khách hàng</param>
        /// <returns>số bản ghi được chỉnh sửa</returns>
        /// CreatedBy: LMDuc (20/04/2021)
        public int Update(Customer customer)
        {
            var rowAffect = _customerRepository.Update(customer);
            return rowAffect;
        }
    }
}
