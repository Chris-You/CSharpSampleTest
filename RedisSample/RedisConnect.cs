using System;
using StackExchange.Redis;
using System.Linq;
using System.Threading.Tasks;

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

        public void RedisString()
        {

            Console.WriteLine("########### string type ###########");
            redisDatabase.StringSet("stringkey", "hello world");
            Console.WriteLine(redisDatabase.StringGet("stringkey"));
            redisDatabase.StringSet("stringkey", "hello korea");
            Console.WriteLine(redisDatabase.StringGet("stringkey"));

            redisDatabase.StringAppend("stringkey", ", hello Sir!");
            Console.WriteLine(redisDatabase.StringGet("stringkey"));

            Console.WriteLine("string del >" + redisDatabase.StringGetDelete("stringkey"));
            Console.WriteLine("string del after >" + redisDatabase.StringGet("stringkey"));

        }

        public void Redishash()
        {

            HashEntry[] hash =
           {
                new HashEntry("name", "ChrisWorld"),
                new HashEntry("email", "helloworld@naver.com"),
                new HashEntry("tel", "+82-000-0000-1111")
            };

            Console.WriteLine("");
            Console.WriteLine("########### hash type ###########");
            redisDatabase.HashSet("hashKey", hash);
            Console.WriteLine(redisDatabase.HashGet("hashKey", "name") + " > " + redisDatabase.HashGet("hashKey", "email"));



            Console.WriteLine("===== hash HashGetAll");
            foreach (var i in redisDatabase.HashGetAll("hashKey"))
            {
                Console.WriteLine(i.Name + ">" + i.Value);
            }

            Console.WriteLine("===== hash HashKeys");
            foreach (var h in redisDatabase.HashKeys("hashKey"))
            {
                Console.WriteLine(h);
            }


            Console.WriteLine("===== hash HashValues");
            foreach (var h in redisDatabase.HashValues("hashKey"))
            {
                Console.WriteLine(h);
            }

            Console.WriteLine("===== hash HashScan");
            foreach (var h in redisDatabase.HashScan("hashKey"))
            {
                Console.WriteLine(h.Name + ">" + h.Value);
            }
            Console.WriteLine("===== hash HashDelete");
            redisDatabase.HashDelete("hashKey", "tel");
            foreach (var i in redisDatabase.HashGetAll("hashKey"))
            {
                Console.WriteLine(i.Name + ">" + i.Value);
            }

        }

        public void RedisSet()
        {
            Console.WriteLine("########### set type ###########");
            redisDatabase.SetAdd("set", "comment1");
            redisDatabase.SetAdd("set", "comment2");
            foreach (var i in redisDatabase.SetMembers("set"))
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("===== 모든 키 type 조회");
            foreach (var i in redisServer.Keys(0, "*"))
            {
                Console.WriteLine(i.ToString() + " > " + redisDatabase.KeyType(i.ToString()));
            }

            Console.WriteLine("");
            Console.WriteLine("########### sorted Set ###########");


            for (int i = 0; i < 5; i++)
            {
                redisDatabase.SortedSetAdd("sortedSet", "name_" + i.ToString(), i + 1);
            }

            Console.WriteLine("length : " + redisDatabase.SortedSetLength("sortedSet"));


            Console.WriteLine(string.Join(",\n", redisDatabase.SortedSetScan("sortedSet")));

            Console.WriteLine("name_2 Rank > " + redisDatabase.SortedSetRank("sortedSet", "name_2"));
            Console.WriteLine("=========== sorted Set - SortedSetIncrement");
            redisDatabase.SortedSetIncrement("sortedSet", "name_2", 100);


            Console.WriteLine("=========== sorted Set - Rank Ascending");
            var set3 = redisDatabase.SortedSetRangeByRank("sortedSet", 0, -1, order: Order.Ascending);
            foreach (var s in set3)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("name_2 Rank > " + redisDatabase.SortedSetRank("sortedSet", "name_2"));

            Console.WriteLine("=========== sorted Set- Score Descending");
            var set4 = redisDatabase.SortedSetRangeByScore("sortedSet", 1, order: Order.Descending);
            foreach (var s in set4)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine("=========== sorted Set- SortedSetScan");
            Console.WriteLine(string.Join(",\n", redisDatabase.SortedSetScan("sortedSet")));

            Console.WriteLine("=========== sorted Set- RankWithScores Descending take 2");
            foreach (var k in redisDatabase.SortedSetRangeByRankWithScores("sortedSet", 0, -1, order: Order.Descending).Take(2))
            {
                var keyword = k.ToString().Split(":")[0];
                var date = k.ToString().Split(":")[1];
                Console.WriteLine(keyword + ">" + date);
            }

            Console.WriteLine("=========== sorted Set- ScoreWithScores Descending take 2");
            foreach (var k in redisDatabase.SortedSetRangeByScoreWithScores("sortedSet", order: Order.Descending).Take(2))
            {
                var keyword = k.ToString().Split(":")[0];
                var date = k.ToString().Split(":")[1];
                Console.WriteLine(keyword + ">" + date);
            }
        }

    }
}
