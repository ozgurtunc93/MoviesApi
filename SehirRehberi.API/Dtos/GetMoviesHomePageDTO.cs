using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos
{
    public class GetMoviesHomePageDTO
    {
        public int PublisherMovies_Id { get; set; }
        public string TitleTurkish { get; set; }
        public string Year { get; set; }
        public string ImdbRating { get; set; }
        public string ImagePath { get; set; }
    }
}
