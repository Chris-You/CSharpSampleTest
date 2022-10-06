using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace SampleProject
{
    public class RedisConnect
    {
        private ConnectionMultiplexer _conntction;
        public IDatabase redisDatabase;
        public IServer redisServer;

        public RedisConnect(string host, string port, string pass, string db)
        {
            this._conntction = ConnectionMultiplexer.Connect(host + ":" + port + ",password=" + pass+ ",DefaultDatabase=" + db);
            if (_conntction.IsConnected)
            {
                this.redisDatabase = this._conntction.GetDatabase();
                this.redisServer = this._conntction.GetServer(host + ":" + port);
            }
        }
    }
}
