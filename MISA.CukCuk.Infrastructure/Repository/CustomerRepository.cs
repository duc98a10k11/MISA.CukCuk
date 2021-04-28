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
        public bool CheckCustomerCodeExists(string customerCode)
        {
            //IDbConnection dbconnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            //DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("@m_CustomerCode", customerCode);
            //var customerCodeExists = dbconnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", dynamicParameters, commandType: CommandType.StoredProcedure);
            //return customerCodeExists;

            using (IDbConnection dbconnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB")))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerCode", customerCode);
                var customerCodeExists = dbconnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", dynamicParameters, commandType: CommandType.StoredProcedure);
                return customerCodeExists;
            }
        }

        public int Delete(Guid customerId)
        {
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var rowsAffect = dbConnection.Execute("Proc_DeleteCustomer", param: parameters,commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public IEnumerable<Customer> GetAll()
        {
            //2. Kết nối connection
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            //3. Lấy dữ liệu từ DB
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //4. Trả về kết quả
            return customers;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            //var customers = dbConnection.Query<Customer>("SELECT * FROM Customer WHERE 1=0");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var customer1 = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById",param: parameters, commandType: CommandType.StoredProcedure);
            return customer1;
        }

        public int Insert(Customer customer)
        {
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            var rowsAffect = dbConnection.Execute("Proc_InsertCustomer", param: customer,commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public int Update(Customer customer)
        {
            IDbConnection dbConnection = new MySqlConnection(_configuration.GetConnectionString("connectionDB"));
            var rowsAffect = dbConnection.Execute("Proc_UpdateCustomer", param: customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
