using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Models
{
    public class UserComment
    {
        [Key]
        public int Id { get; set; }
        public User  User { get; set; }
        public string Comment { get; set; }
        public bool PublisherComment  { get; set; }
        public DateTime SystemInsertTime { get; set; }
        public DateTime SystemUpdateTime { get; set; }
        public string SystemInsertUser { get; set; }
        public string SystemUpdateUser { get; set; }
    }
}
