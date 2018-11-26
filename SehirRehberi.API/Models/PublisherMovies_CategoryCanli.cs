using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Models
{
    public class PublisherMovies_CategoryCanlis
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public Nullable<int> PM_Id { get; set; }

        public virtual CategoryCanli CategoryCanli { get; set; }
        public virtual PublisherMoviesCanli PublisherMoviesCanli { get; set; }
    }
}
