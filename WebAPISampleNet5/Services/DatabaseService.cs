using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISampleNet5.Models;
using Microsoft.Extensions.Configuration;
using System.Transactions;

namespace WebAPISampleNet5.Services
{

    public interface IDatabaseService
    {
        IEnumerable<LogModel> GetLogAll();
        int InsLog();
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
            using (var tran = new TransactionScope())
            {

                try
                {
                    // log ins
                    repository.Execute("insert into log values (getdate(), '0', 'Debug', 'ClassName', 'Error~~1');");
                    // Error
                    // log ins
                    repository.Execute("insert into log values (1, getdate(), '0', 'Debug', 'ClassName', 'Error~~2');");

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    // roll the transaction back
                    // logging 
                    // handle the error however you need to.
                }
            }

            return 0;
        }
    }
}
