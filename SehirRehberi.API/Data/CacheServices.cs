using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SehirRehberi.API.Dtos;

namespace SehirRehberi.API.Data
{
    public class CacheServices : ICacheServices
    {
        private readonly IMemoryCache _cache;
        public CacheServices(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void GetCache(CacheModel cacheModel)
        {
            CacheModel cache = new CacheModel();
            _cache.TryGetValue("CacheModel", out cache);
        }

        public bool IsAuthentication(CacheModel cacheModel)
        {
            CacheModel cache = new CacheModel();
            _cache.TryGetValue("CacheModel", out cache);
            if (cache != null)
            {
                if (cache.TokenTime < DateTime.Now.AddDays(-1))
                {
                    return false;
                }
                else
                return true;
            }
            return false;
        }

        public void SetCache(CacheModel cacheModel)
        {
            _cache.Set("CacheModel", cacheModel, TimeSpan.FromDays(1));
        }
    }
}
