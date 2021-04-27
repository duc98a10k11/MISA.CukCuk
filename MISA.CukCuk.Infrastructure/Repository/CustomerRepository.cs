using Dapper;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public bool CheckCustomerCodeExist(string customerCode)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@m_CustomerCode", customerCode);
                var check = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", param: parameters, commandType: CommandType.StoredProcedure);
                return check;
            }
        }

        public bool CheckPhoneNumberExist(string phonNumber)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PhoneNumber", phonNumber);
                var check = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckPhoneNumberExists", param: parameters, commandType: CommandType.StoredProcedure);
                return check;
            }
        }
    }
}
