using System;
using StackExchange.Redis;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== REDIS Sample World! =====");

            RedisConnect redis = new RedisConnect(
                                                Config.redis_ip, 
                                                Config.redis_port, 
                                                Config.redis_pass, 
                                                Config.redis_default_db);

                                                

            redis.RedisString();

            redis.Redishash();

            redis.RedisSet();

        }




      
    }
}
