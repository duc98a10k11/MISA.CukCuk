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
        
        ICustomerService _customerService;
        ICustomerRepository _customerRepository;
        /// <summary>
        /// Contructor
        /// </summary>
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
            // kiểm tra mã khách hàng có null hay không
            // return: 400 - nếu mã khách hàng null
                if (customer.CustomerCode == null)
                {
                    return BadRequest();
                }
                else
                {
                    // Thực hiện thêm dữ liệu
                    var rowAffect = _customerService.Insert(customer);
                    // kiểm tra và trả về kết quả
                    // return:
                    // 201 - thêm thành công
                    // 204 - không thêm được vào db
                    if (rowAffect > 0)
                    {
                        return StatusCode(201, rowAffect);
                    }
                    else
                    {
                        return NoContent();
                    }
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
        public IActionResult Put(Guid customerID ,Customer customer)
        {
                //kiểm tra id customer, nếu trùng thì cho phép thực hiện cập nhật
                if (customer.CustomerId == customerID)
                {
                    //Thực hiện cập nhật
                    var rowAffect = _customerService.Update(customerID,customer);
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
                else
                {
                    return NoContent();
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
    }
}
