using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos
{
    public class GetMovisRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
      
    }
}
