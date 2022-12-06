using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplicationMVC.Services
{
    public class RepositoryBase
    {
        private string _connectionString = string.Empty;
        private IDbConnection _connection = null;
        private IConfiguration _config;

        public RepositoryBase(IConfiguration config)
        {
            _config = config;

            _connectionString = _config.GetConnectionString("dtpia_dev");
        }

        public IDbConnection Connection
        {
            get
            {
                _connection = new SqlConnection(_connectionString);

                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var results = Connection.Query<T>(sql, param, null, true, commandTimeout, commandType);
            return results ?? new List<T>();
        }

        public T QuerySingle<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var results = Connection.Query<T>(sql, param, null, true, commandTimeout, commandType);
            if (results != null && results.Count() > 0)
            {
                return results.FirstOrDefault<T>();
            }
            return default(T);
        }

        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Connection.Execute(sql, param as object, transaction, commandTimeout, CommandType.Text);
        }

        public int ExecuteProc(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Connection.Execute(sql, param as object, transaction, commandTimeout, CommandType.StoredProcedure);
        }

        public int InsLog()
        {
            return Connection.Execute("insert into log values (getdate(), '0', 'Debug', 'ClassName', 'Error~~1');");
        }

        public int InsLogError()
        {
            return Connection.Execute("insert into log values (1,getdate(), '0', 'Debug', 'ClassName', 'Error~~1');");
        }
    }
}