using System;
using System.Runtime.Caching;

namespace DirectSupply.Anonymize.Service.Caching
{
    public class StoriesCache : ICache
    {
        private MemoryCache _cache;

        public StoriesCache()
        {
            _cache = new MemoryCache(CacheNames.StoriesCacheName);
        }

        public void AddItem(string key, object value)
        {
            CacheItem cacheItem = new CacheItem(key, value, CacheNames.StoriesCacheName);

            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
            };

            _cache.Add(cacheItem, cacheItemPolicy);
        }

        public bool ContainsKey(string key)
        {
            return _cache.Contains(key);
        }

        public object GetItem(string key)
        {
            return _cache.Get(key);
        }
    }
}
