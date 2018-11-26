using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Models
{
    public  class CategoryCanli
    {
        public CategoryCanli()
        {
            this.PublisherMovies_CategoryCanli = new List<PublisherMovies_CategoryCanlis>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TurkishName { get; set; }
        public DateTime SystemInsertTime { get; set; }
        public DateTime SystemUpdateTime { get; set; }
        public string SystemInsertUser { get; set; }
        public string SystemUpdateUser { get; set; }
        public virtual ICollection<PublisherMovies_CategoryCanlis> PublisherMovies_CategoryCanli { get; set; }
    }
}
