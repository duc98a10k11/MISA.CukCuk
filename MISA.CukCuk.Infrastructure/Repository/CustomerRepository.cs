using Dapper;
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
        public bool CheckCustomerCodeExists(string customerCode)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid customerId)
        {
            string connectionString = "" +
                 "Host = 47.241.69.179;" +
                 "Port = 3306;" +
                 "Database = MF0_NVManh_CukCuk02;" +
                 "User Id= dev;" +
                 "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var rowsAffect = dbConnection.Execute("Proc_DeleteCustomer", param: parameters,commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public IEnumerable<Customer> GetAll()
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
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //4. Trả về kết quả
            return customers;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            string connectionString = "" +
              "Host = 47.241.69.179;" +
              "Port = 3306;" +
              "Database = MF0_NVManh_CukCuk02;" +
              "User Id= dev;" +
              "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //var customers = dbConnection.Query<Customer>("SELECT * FROM Customer WHERE 1=0");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            var customer1 = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById",param: parameters, commandType: CommandType.StoredProcedure);
            return customer1;
        }

        public int Insert(Customer customer)
        {
            string connectionString = "" +
                   "Host = 47.241.69.179;" +
                   "Port = 3306;" +
                   "Database = MF0_NVManh_CukCuk02;" +
                   "User Id= dev;" +
                   "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var rowsAffect = dbConnection.Execute("Proc_InsertCustomer", param: customer,commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public int Update(Customer customer)
        {
            string connectionString = "" +
                  "Host = 47.241.69.179;" +
                  "Port = 3306;" +
                  "Database = MF0_NVManh_CukCuk02;" +
                  "User Id= dev;" +
                  "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var rowsAffect = dbConnection.Execute("Proc_UpdateCustomer", param: customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
