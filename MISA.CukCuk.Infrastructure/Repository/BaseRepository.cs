using Dapper;
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
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {
        string tableName = typeof(MISAEntity).Name;
        protected string connectionString = "" +
            "Host = 47.241.69.179;" +
            "Port = 3306;" +
            "Database = MF0_NVManh_CukCuk02;" +
            "User Id= dev;" +
            "Password = 12345678;";
        protected IDbConnection dbConnection;
        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var rowsAffect = dbConnection.Execute($"Proc_Delete{tableName}ById", param: parameters,
                    commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var result = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public MISAEntity GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var result = dbConnection.QueryFirstOrDefault<MISAEntity>($"Proc_Get{tableName}ById", param: parameters, commandType: CommandType.StoredProcedure);
                return result;

            }
        }

        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowAffect = dbConnection.Execute($"Proc_Insert{tableName}", param: entity, commandType: CommandType.StoredProcedure);
                    return rowAffect;
            }
        }

        public int Update(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowAffect = dbConnection.Execute($"Proc_Update{tableName}", param: entity,
                    commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
        }
    }
}
