using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos
{
    public class CacheModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Token { get; set; }
        public DateTime TokenTime { get; set; }
    }
}
