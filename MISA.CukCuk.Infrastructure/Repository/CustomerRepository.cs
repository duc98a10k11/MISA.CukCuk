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
    /// <summary>
    /// Khách hàng
    /// </summary>
    /// CreatedBy: LMDuc (27/04/2021)
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// kiểm tra tồn tại của mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>
        /// true - nếu mã khách hàng đã tồn tại
        /// false - mã khách hàng chưa tồn tại
        /// </returns>
        /// CreatedBy: LMDuc (27/04/2021)
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

        /// <summary>
        /// Kiểm tra tồn tại số điện thoại
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>
        /// true - số điện thoại đã tồn tại
        /// false - số điện thoại chưa tồn tại
        /// </returns>
        /// CreatedBy: LMDuc(27/04/2021)
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@m_PhoneNumber", phoneNumber);
                var check = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckPhoneNumberExists", param: parameters, commandType: CommandType.StoredProcedure);
                return check;
            }
        }
    }
}
