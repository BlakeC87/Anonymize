using System;
using System.Runtime.Caching;

namespace DirectSupply.Anonymize.Service.Caching
{
    public class NamesCache : ICache
    {
        private MemoryCache _cache;

        public NamesCache()
        {
            _cache = new MemoryCache(CacheNames.NamesCacheName);
        }

        public void AddItem(string key, object value)
        {
            CacheItem cacheItem = new CacheItem(key, value, CacheNames.NamesCacheName);

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
