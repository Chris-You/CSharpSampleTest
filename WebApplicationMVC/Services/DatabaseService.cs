using System;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.Extensions.Configuration;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services
{
    public interface IDatabaseService
    {
        IEnumerable<LogModel> GetLogAll();

        int InsLog();

        int InsLogTran();
    }

    public class DatabaseService : IDatabaseService
    {
        private RepositoryBase repository;

        public DatabaseService(IConfiguration config)
        {
            repository = new RepositoryBase(config);
        }

        public IEnumerable<LogModel> GetLogAll()
        {
            var list = repository.Query<LogModel>("select * from Log with(nolock);");

            return list;
        }

        public int InsLog()
        {
            int ret = 0;
            using (var tran = new TransactionScope())
            {
                try
                {
                    // log ins
                    ret = repository.InsLog();
                    ret = repository.InsLogError();

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    // roll the transaction back
                    // logging
                    // handle the error however you need to.
                }
            }

            using (var tran = new TransactionScope())
            {
                try
                {
                    // log ins
                    ret = repository.InsLog();
                    ret = repository.InsLog();

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    // roll the transaction back
                    // logging
                    // handle the error however you need to.
                }
            }

            return ret;
        }

        public int InsLogTran()
        {
            int ret = 0;
            try
            {
                // log ins
                ret = repository.InsLog();
                ret = repository.InsLogError();
            }
            catch (Exception ex)
            {
                // roll the transaction back
                // logging
                // handle the error however you need to.
            }

            return ret;
        }
    }
}