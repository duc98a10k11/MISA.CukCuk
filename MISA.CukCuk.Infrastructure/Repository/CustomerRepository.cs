using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.AppCore.Entities;
using MISA.CukCuk.AppCore.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        IConfiguration _configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Kiểm tra mã khách hàng tồn tại trong hệ thống
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns></returns>
        /// CreateBy:LMDuc (22/04/2021)
        public bool CheckCustomerCodeExists(string customerCode)
        {
            //Kết nốt connection
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectDB"));
            // Thực hiện lấy dữ liệu
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerCode", customerCode);
            bool check = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists",  param: parameters, commandType: CommandType.StoredProcedure);
            return check;
        }

        /// <summary>
        /// Xóa khách hàng theo id
        /// </summary>
        /// <param name="customerId">id khách hàng</param>
        /// <returns></returns>
        /// CreateBy: LMDuc (22/04/2021)
        public int Delete(Guid customerId)
        {
            // kết nối connection
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectDB"));
            //thực hiện xóa 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var rowsAffect = dbConnection.Execute("Proc_DeleteCustomer", param: parameters,commandType: CommandType.StoredProcedure);
            // trả về kết quả
            return rowsAffect;
        }

        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LMDuc (22/04/2021)
        public IEnumerable<Customer> GetAll()
        {
          
            //1. Kết nối connection
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectDB"));
            //2. Lấy dữ liệu từ DB
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //3. Trả về kết quả
            return customers;
        }

        /// <summary>
        /// Tìm kiếm khách hàng theo id
        /// </summary>
        /// <param name="customerId">id khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (22/04/2021)
        public Customer GetCustomerById(Guid customerId)
        {
            //kết nốt connection
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectDB"));
            //var customers = dbConnection.Query<Customer>("SELECT * FROM Customer WHERE 1=0");
            // thực hiện lọc khách hàng
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById",param: parameters, commandType: CommandType.StoredProcedure);
            // trả về kết quả
            return customer;
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">thông tin khách hàng</param>
        /// <returns>
        /// Số bản ghi đã thêm
        /// </returns>
        /// CreatedBy: LMDuc(22/04/2021)
        public int Insert(Customer customer)
        {
            //kết nối connection    
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectDB"));
            // thực hiện lệnh thêm db
            var rowsAffect = dbConnection.Execute("Proc_InsertCustomer", param: customer,commandType: CommandType.StoredProcedure);
            // trả về kết quả
            return rowsAffect;
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">thông tin khách hàng</param>
        /// <returns></returns>\
        /// CreatedBy: LMDuc (22/04/2021)
        public int Update(Customer customer)
        {
            // kết nối connection
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectDB"));
            // Thực hiện cập nhật thông tin khách hàng
            var rowsAffect = dbConnection.Execute("Proc_UpdateCustomer", param: customer, commandType: CommandType.StoredProcedure);
            // trả về kết quả
            return rowsAffect;
        }
    }
}
