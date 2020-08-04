using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNosqlGuestbook
{
    public class RedisConnectionProvier
    {
        private readonly IDatabase conn;
        public RedisConnectionProvier() 
        {
            ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect("redis-server:6379");
            conn = muxer.GetDatabase();
        }

        public void Insert(string key, string val)
        {
            conn.StringSet(key, val);
        }

        public string Get(string key)
        {
            var res = conn.StringGet(key);
            return res.IsNullOrEmpty ? null : res.ToString();
        }
    }
}
