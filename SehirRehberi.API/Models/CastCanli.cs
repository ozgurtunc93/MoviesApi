using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Models
{
    public  class CastCanli
    {
        public CastCanli()
        {
            PublisherMovies_CastCanli = new List<PublisherMovies_CastCanli>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SystemInsertTime { get; set; }
        public DateTime SystemUpdateTime { get; set; }
        public string SystemInsertUser { get; set; }
        public string SystemUpdateUser { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<PublisherMovies_CastCanli> PublisherMovies_CastCanli { get; set; }
    }
}
