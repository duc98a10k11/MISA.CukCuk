using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Dapper;
using MISA.CukCuk.Api.Model;
using MISA.ApplicationCore.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _customerRepository;
        //private CustomerRepository _customerService;
        //GET: api/<CustomerController>
        /// <summary>
        /// Lấy dữ liệu toàn bộ khách hàng
        /// </summary>
        /// <returns>
        /// HttpStatusCode 200 - có dữ liệu trả về
        /// HttpStatusCode 204 - không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: LMDuc(17/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            ////1. Khởi tạo Connection
            //string connectionString = "" +
            //   "Host = 47.241.69.179;" +
            //   "Port = 3306;" +
            //   "User Id = dev;" +
            //   "Password = 12345678;" +
            //   "Database = MF0_NVManh_CukCuk02;";
            ////2. Kết nối connection
            //IDbConnection dbConnection = new MySqlConnection(connectionString);
            ////3. Lấy dữ liệu từ DB

            //var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //4. Trả về kết quả cho người dùng
            var customers = _customerRepository.GetAll();
            if (customers != null)
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
        /// CreatedBy: LMDuc (17/04/2021)

        // GET api/<CustomerController>/5
        [HttpGet("{CustomerId}")]
        public IActionResult Get(Guid CustomerId)
        {
            //1. Khởi tạo Connection
            string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "Database = MF0_NVManh_CukCuk02;";
            //2. Kết nối connection
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //3. Lấy dữ liệu từ DB
            //DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("CustomerId", CustomerId);
            var customers = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", new { CustomerId = CustomerId }, commandType: CommandType.StoredProcedure);
            //4. Trả về kết quả cho người dùng
            if (customers != null)
            {
                return Ok(customers);
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
        /// CreatedBy: LMDuc (17/04/2021)
        [HttpPost]
        public IActionResult Post(Customer customer)
        {


            // Validate dữ liệu:
            //- check các thông tin bắt buộc nhập
            if (string.IsNullOrEmpty(customer.CustomerCode))
            {
                var response = new
                {
                    devMsg = "Mã khách hàng không được phép để trống",
                    MISACode = "001"
                };
                return BadRequest(response);
            }
            // - check mã có trùng hay không?
            string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "Database = MF0_NVManh_CukCuk02;";
            IDbConnection dbconnection = new MySqlConnection(connectionString);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_CustomerCode", customer.CustomerCode);
            var customerCodeExists = dbconnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", dynamicParameters, commandType: CommandType.StoredProcedure);
            if (customerCodeExists)
            {
                var response = new
                {
                    devMsg = "Mã khách hàng đã tồn tại trong hệ thống!",
                    MISACode = "002"
                };
                return BadRequest(response);
            }
            // Thực hiện thêm dữ liệu
            var rowAffect = dbconnection.Execute("Proc_InsertCustomer", param: customer, commandType: CommandType.StoredProcedure);
            if (rowAffect > 0)
            {
                return StatusCode(200, rowAffect);
            }
            else
            {
                return NoContent();
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
        [HttpPut("{CustomerId}")]
        public IActionResult Put(Guid CustomerId, Customer customer)
        {
            //1. Khởi tạo Connection
            string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "Database = MF0_NVManh_CukCuk02;";
            //2. Kết nối DB
            IDbConnection dbconnection = new MySqlConnection(connectionString);
            //3. Thực hiện sửa dữ liệu trên db
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(customer);
            //dynamicParameters.AddDynamicParams("@m_CustomerId", CustomerId, "@m_CustomerCode", customer.CustomerCode,
            //    "@m_FullName", customer.FullName, "@m_MemberCardCode", customer.MemberCardCode,
            //    "@m_CustomerGroupId", customer.CustomerGroupId, "@m_DateOfBirth", customer.DateOfBirth,
            //    "@m_Gender", customer.Gender, "@m_Email", customer.Email, "@m_PhoneNumber", customer.PhoneNumber,
            //    "@m_CompanyName", customer.CompanyName, "@m_CompanyTaxCode", customer.CompanyTaxCode,
            //    "@m_Address", customer.Address, "@m_ModifiedDate", customer.ModifiedDate);
            var rowAffect = dbconnection.Query<bool>("Proc_UpdateCustomer", dynamicParameters, commandType: CommandType.StoredProcedure);
            //4. kiểm tra kết quả
            if (rowAffect != null)
            {
                return Ok("Thông tin đã được chỉnh sửa");
            }
            else
            {
                return NoContent();

            }

            // DELETE api/<CustomerController>/5
            //[HttpDelete("{id}")]
            //public void Delete(int id)
            //{
            //}
        }
    }
}
