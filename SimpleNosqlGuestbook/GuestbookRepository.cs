using Newtonsoft.Json;
using SimpleNosqlGuestbook.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNosqlGuestbook
{
    public class GuestbookRepository : IGenericRepository<GuestbookRecordDto>
    {
        private readonly RedisConnectionProvier _redisProvider;
        private const string GUEST_POSTS_KEY = "guestposts";

        public GuestbookRepository(RedisConnectionProvier redisProvider)
        {
            _redisProvider = redisProvider;
        }

        public void Add(GuestbookRecordDto item)
        {
            var current = GetAll();
            current.Add(item);

            var str = JsonConvert.SerializeObject(current);
            _redisProvider.Insert(GUEST_POSTS_KEY, str);
        }

        public void Test()
        {
            _redisProvider.Insert("foo", "{'hello': 'world'}");

            var x = _redisProvider.Get("foo");
            var y = 1;
        }

        public List<GuestbookRecordDto> GetAll()
        {
            var guestPostsStr = _redisProvider.Get(GUEST_POSTS_KEY);
            if (guestPostsStr == null)
                return new List<GuestbookRecordDto>();

            var guestPosts = JsonConvert.DeserializeObject<List<GuestbookRecordDto>>(guestPostsStr);
            return guestPosts;
        }
    }
}
