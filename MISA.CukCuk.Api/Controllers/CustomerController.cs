using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Dapper;

using MISA.CukCuk.AppCore.Interfaces.Repository;
using MISA.CukCuk.AppCore.Interfaces.Service;
using MISA.CukCuk.AppCore.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _customerRepository;
        ICustomerService _customerService;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="customerService"></param>
        /// <param name="customerRepository"></param>
        /// CreatedBy: LMDuc (20/04/2021)
        public CustomerController(ICustomerService customerService, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
        }

        /// <summary>
        /// Lấy dữ liệu toàn bộ khách hàng
        /// </summary>
        /// <returns>
        /// HttpStatusCode 200 - có dữ liệu trả về
        /// HttpStatusCode 204 - không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: LMDuc (20/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //1. Lấy dữ liệu
                var customers = _customerRepository.GetAll();
                //2. Trả về cho người dùng
                if (customers != null)
                {
                    return Ok(customers);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lấy dữ liệu khách hàng theo id
        /// </summary>
        /// <param name="CustomerId">id khách hàng</param>
        /// <returns>
        /// HttpStatusCode 200 - có dữ liệu trả về
        /// HttpStatusCode 204 - không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: LMDuc (20/04/2021)
        [HttpGet("CustomerId")]
        public IActionResult Get(Guid CustomerId)
        {
            try
            {
                //1. Lấy dữ liệu
                var customer = _customerService.GetCustomerById(CustomerId);
                //2. Trả về cho người dùng
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">thông tin khách hàng</param>
        /// <returns>
        /// HttpStatusCode 201 - thêm mới thành công
        /// HttpStatusCode 204 - không thêm được vào db
        /// HttpStatusCode 400 - dữ liệu đầu vào không hợp lệ
        /// HttpStatusCode 500 - có lỗi xảy ra phía server (exception,....)
        /// </returns>
        /// CreatedBy: LMDuc (20/04/2021)
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            try
            {
                // Thực hiện thêm dữ liệu
                int rowAffect = _customerService.Insert(customer);
                if (rowAffect > 0)
                {
                    return StatusCode(201, rowAffect);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">thông tin khách hàng</param>
        /// <param name="CustomerId">id khách hàng</param>
        /// <return>
        /// HttpStatusCode 200 - sửa thành công
        /// HttpStatusCode 204 - Không lưu được vào db
        /// </return>
        /// CreatedBy: LMDuc (19/04/2021)
        // PUT api/<CustomerController>/5
        [HttpPut("CustomerId")]
        public IActionResult Put(Guid CustomerId, Customer customer)
        {

            try
            {
                int rowAffect = _customerService.Update(customer);
                //4. kiểm tra kết quả
                if (rowAffect > 0)
                {
                    return Ok(rowAffect);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }

            

        }

        /// <summary>
        /// Xóa khách hàng theo id
        /// </summary>
        /// <param name="customerId">id khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (22/04/2021)
        [HttpDelete("customerId")]
        public IActionResult Delete(Guid customerId)
        {
            try
            {
                //1. Thực hiện xóa
                int rowAffect = _customerService.Delete(customerId);
                if (rowAffect > 0)
                {
                    return Ok(rowAffect);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
