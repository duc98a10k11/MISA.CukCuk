using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Controler Customer Group
    /// </summary>
    /// CreateBy: LMDuc(27/04/2021)
    /// 
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        ICustomerGroupRepository _customerGroupRepository;
        ICustomerGroupService _customerGroupService;
        public CustomerGroupController(ICustomerGroupRepository customerGroupRepository, ICustomerGroupService customerGroupService)
        {
            _customerGroupRepository = customerGroupRepository;
            _customerGroupService = customerGroupService;
        }
        /// <summary>
        /// Lấy dữ liệu toàn bộ nhóm khách hàng
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
                //lấy dữ liệu
                var customerGroups = _customerGroupRepository.GetAll();
                //kiểm tra và trả về kết quả
                if (customerGroups.Count() > 0)
                {
                    return Ok(customerGroups);
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
        /// <param name="CustomerGroupId">id nhóm khách hàng</param>
        /// <returns>
        /// HttpStatusCode 200 - có dữ liệu trả về
        /// HttpStatusCode 204 - không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: LMDuc (27/04/2021)
        [HttpGet("{CustomerGroupId}")]
        public IActionResult Get(Guid CustomerGroupId)
        {
            try
            {
                //lấy dữ liệu từ db
                var customerGroup = _customerGroupRepository.GetById(CustomerGroupId);
                // Trả về kết quả cho người dùng
                if (customerGroup != null)
                {
                    return Ok(customerGroup);
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
        /// <param name="customerGroup">thông tin khách hàng</param>
        /// <returns>
        /// HttpStatusCode 201 - thêm mới thành công
        /// HttpStatusCode 204 - không thêm được vào db
        /// HttpStatusCode 400 - dữ liệu đầu vào không hợp lệ
        /// HttpStatusCode 500 - có lỗi xảy ra phía server (exception,....)
        /// </returns>
        /// CreatedBy: LMDuc (27/04/2021)
        [HttpPost]
        public IActionResult Post(CustomerGroup customerGroup)
        {
            try
            {
                // Thực hiện thêm dữ liệu
                var rowAffect = _customerGroupService.Insert(customerGroup);
                //kiểm tra và trả về kết quả
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
        /// Sửa thông tin nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">thông tin  nhóm khách hàng</param>
        /// <return>
        /// HttpStatusCode 200 - sửa thành công
        /// HttpStatusCode 204 - Không lưu được vào db
        /// </return>
        /// CreatedBy: LMDuc (27/04/2021)
        // PUT api/<CustomerController>/5
        [HttpPut("{CustomerGroupId}")]
        public IActionResult Put(Guid customerGroupId, CustomerGroup customerGroup)
        {
            try
            {
                //thực hiện cập nhật dữ liệu
                var rowAffect = _customerGroupService.Update(customerGroupId,customerGroup);
                // kiểm tra kết quả
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
        /// <param name="id"> id nhóm khách hàng</param>
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
                var rowAffect = _customerGroupService.Delete(id);
                // kiểm tra kết quả
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
