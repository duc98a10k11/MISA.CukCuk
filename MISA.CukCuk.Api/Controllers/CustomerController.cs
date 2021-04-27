using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Dapper;
using MISA.CukCuk.Core.Interfaces.Services;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Entities;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Controler Customer
    /// </summary>
    /// CreateBy: LMDuc(27/04/2021)
    /// 
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Contructor
        /// </summary>
        ICustomerService _customerService;
        ICustomerRepository _customerRepository;
        
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
        /// CreatedBy: LMDuc (27/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // thực hiện lấy dữ liệu
                var customers = _customerRepository.GetAll();
                // kiểm tra và trả về kết quả
                if (customers.Count() > 0)
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
        /// CreatedBy: LMDuc (27/04/2021)
        [HttpGet("{CustomerId}")]
        public IActionResult Get(Guid CustomerId)
        {
            try
            {
                // lấy dữ liệu
                var customer = _customerRepository.GetById(CustomerId);
                // Trả về kết quả cho người dùng
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
        /// CreatedBy: LMDuc (27/04/2021)
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            try
            {
                // Thực hiện thêm dữ liệu
                var rowAffect = _customerService.Insert(customer);
                // kiểm tra và trả về kết quả
                if (rowAffect > 0)
                {
                    return StatusCode(200, rowAffect);
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
        /// <return>
        /// HttpStatusCode 200 - sửa thành công
        /// HttpStatusCode 204 - Không lưu được vào db
        /// </return>
        /// CreatedBy: LMDuc (27/04/2021)
        // PUT api/<CustomerController>/5
        [HttpPut("{CustomerId}")]
        public IActionResult Put( Customer customer)
        {
            try
            {
                //Thực hiện cập nhật
                var rowAffect = _customerService.Update(customer);
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
        /// <param name="id"> id khách hàng</param>
        /// <return>
        /// HttpStatusCode 200 - sửa thành công
        /// HttpStatusCode 204 - Không lưu được vào db
        /// </return>
        /// CreatedBy: LMDuc (27/04/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                // thực hiện xóa
                var rowAffect = _customerRepository.Delete(id);
                //kiểm tra kết quả trả về
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
