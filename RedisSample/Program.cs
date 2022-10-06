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

            string ip = Config.redis_ip;
            string port = Config.redis_port;
            string pass = Config.redis_pass;
            string db = Config.redis_default_db;


            RedisSample redis = new RedisSample(ip, port, pass, db);

            
            RedisString(redis);

            Redishash(redis);

            RedisSet(redis);

        }


        public static void RedisString(RedisSample redis)
        {

            Console.WriteLine("########### string type ###########");
            redis.redisDatabase.StringSet("stringkey", "hello world");
            Console.WriteLine(redis.redisDatabase.StringGet("stringkey"));
            redis.redisDatabase.StringSet("stringkey", "hello korea");
            Console.WriteLine(redis.redisDatabase.StringGet("stringkey"));

            redis.redisDatabase.StringAppend("stringkey", ", hello Sir!");
            Console.WriteLine(redis.redisDatabase.StringGet("stringkey"));

            Console.WriteLine("string del >" + redis.redisDatabase.StringGetDelete("stringkey"));
            Console.WriteLine("string del after >" + redis.redisDatabase.StringGet("stringkey"));

        }


        public static void Redishash(RedisSample redis)
        {

            HashEntry[] hash =
           {
                new HashEntry("name", "ChrisWorld"),
                new HashEntry("email", "helloworld@naver.com"),
                new HashEntry("tel", "+82-000-0000-1111")
            };

            Console.WriteLine("");
            Console.WriteLine("########### hash type ###########");
            redis.redisDatabase.HashSet("hashKey", hash);
            Console.WriteLine(redis.redisDatabase.HashGet("hashKey", "name") + " > " + redis.redisDatabase.HashGet("hashKey", "email"));



            Console.WriteLine("===== hash HashGetAll");
            foreach (var i in redis.redisDatabase.HashGetAll("hashKey"))
            {
                Console.WriteLine(i.Name + ">" + i.Value);
            }

            Console.WriteLine("===== hash HashKeys");
            foreach (var h in redis.redisDatabase.HashKeys("hashKey"))
            {
                Console.WriteLine(h);
            }


            Console.WriteLine("===== hash HashValues");
            foreach (var h in redis.redisDatabase.HashValues("hashKey"))
            {
                Console.WriteLine(h);
            }

            Console.WriteLine("===== hash HashScan");
            foreach (var h in redis.redisDatabase.HashScan("hashKey"))
            {
                Console.WriteLine(h.Name + ">" + h.Value);
            }
            Console.WriteLine("===== hash HashDelete");
            redis.redisDatabase.HashDelete("hashKey", "tel");
            foreach (var i in redis.redisDatabase.HashGetAll("hashKey"))
            {
                Console.WriteLine(i.Name + ">" + i.Value);
            }

        }


        public static void RedisSet(RedisSample redis)
        {
            Console.WriteLine("########### set type ###########");
            redis.redisDatabase.SetAdd("set", "comment1");
            redis.redisDatabase.SetAdd("set", "comment2");
            foreach (var i in redis.redisDatabase.SetMembers("set"))
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("===== 모든 키 type 조회");
            foreach (var i in redis.redisServer.Keys(0, "*"))
            {
                Console.WriteLine(i.ToString() + " > " + redis.redisDatabase.KeyType(i.ToString()));
            }

            Console.WriteLine("");
            Console.WriteLine("########### sorted Set ###########");


            for (int i = 0; i < 5; i++)
            {
                redis.redisDatabase.SortedSetAdd("sortedSet", "name_" + i.ToString(), i + 1);
            }

            Console.WriteLine("length : " + redis.redisDatabase.SortedSetLength("sortedSet"));


            Console.WriteLine(string.Join(",\n", redis.redisDatabase.SortedSetScan("sortedSet")));

            Console.WriteLine("name_2 Rank > " + redis.redisDatabase.SortedSetRank("sortedSet", "name_2"));
            Console.WriteLine("=========== sorted Set - SortedSetIncrement");
            redis.redisDatabase.SortedSetIncrement("sortedSet", "name_2", 100);


            Console.WriteLine("=========== sorted Set - Rank Ascending");
            var set3 = redis.redisDatabase.SortedSetRangeByRank("sortedSet", 0, -1, order: Order.Ascending);
            foreach (var s in set3)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("name_2 Rank > " + redis.redisDatabase.SortedSetRank("sortedSet", "name_2"));

            Console.WriteLine("=========== sorted Set- Score Descending");
            var set4 = redis.redisDatabase.SortedSetRangeByScore("sortedSet", 1, order: Order.Descending);
            foreach (var s in set4)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine("=========== sorted Set- SortedSetScan");
            Console.WriteLine(string.Join(",\n", redis.redisDatabase.SortedSetScan("sortedSet")));

            Console.WriteLine("=========== sorted Set- RankWithScores Descending take 2");
            foreach (var k in redis.redisDatabase.SortedSetRangeByRankWithScores("sortedSet", 0, -1, order: Order.Descending).Take(2))
            {
                var keyword = k.ToString().Split(":")[0];
                var date = k.ToString().Split(":")[1];
                Console.WriteLine(keyword + ">" + date);
            }

            Console.WriteLine("=========== sorted Set- ScoreWithScores Descending take 2");
            foreach (var k in redis.redisDatabase.SortedSetRangeByScoreWithScores("sortedSet", order: Order.Descending).Take(2))
            {
                var keyword = k.ToString().Split(":")[0];
                var date = k.ToString().Split(":")[1];
                Console.WriteLine(keyword + ">" + date);
            }
        }


      
    }
}
