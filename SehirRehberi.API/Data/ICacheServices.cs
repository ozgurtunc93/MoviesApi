using SehirRehberi.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Data
{
    public interface ICacheServices
    {
        void SetCache(CacheModel cacheModel);
        void GetCache(CacheModel cacheModel);
        bool IsAuthentication(CacheModel cacheModel);
       
    }
}
