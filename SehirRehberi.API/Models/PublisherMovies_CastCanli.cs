using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Models
{
    public class PublisherMovies_CastCanli
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> Cast_Id { get; set; }
        public Nullable<int> PM_Id { get; set; }

        public virtual CastCanli CastCanli { get; set; }
        public virtual PublisherMoviesCanli PublisherMoviesCanli { get; set; }
    }
}
