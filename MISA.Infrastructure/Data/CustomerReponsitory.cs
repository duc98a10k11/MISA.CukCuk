using Dapper;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Data
{
    class CustomerReponsitory : ICustomerRepository
    {
        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public int EditCustomer(Customer customer, Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetAll()
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
            return (Customer)customers;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
