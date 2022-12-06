using System;
using Dapper;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplicationMVC.Transaction
{
    public class SqlConnectionProvider
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public SqlConnectionProvider(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection GetDbConnection => _connection;

        public IDbTransaction GetTransaction => _transaction;

        public IDbTransaction CreateTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            _transaction = _connection.BeginTransaction();

            return _transaction;
        }
    }
}
