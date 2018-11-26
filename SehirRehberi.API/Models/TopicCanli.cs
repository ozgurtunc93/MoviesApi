using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Models
{
    public  class TopicCanli
    {
        [Key]
        public int PublisherMovies_Id { get; set; }
        public string Title { get; set; }
        public string TitleTurkish { get; set; }
        public string Year { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Directory { get; set; }
        public string Writer { get; set; }
        public string Description { get; set; }
        public string DescriptionTurkish { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string RatingName1 { get; set; }
        public string RatingValue1 { get; set; }
        public string RatingName2 { get; set; }
        public string RatingValue2 { get; set; }
        public string RatingName3 { get; set; }
        public string RatingValue3 { get; set; }
        public string Metascore { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string BoxOffice { get; set; }
        public string DVD { get; set; }
        public string Production { get; set; }
        public string WebSite { get; set; }
        public string TrailerLink { get; set; }
        public string ImagePath { get; set; }
        public Nullable<bool> Publisher { get; set; }
        public DateTime SystemInsertTime { get; set; }
        public DateTime SystemUpdateTime { get; set; }
        public string SystemInsertUser { get; set; }
        public string SystemUpdateUser { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaTitle { get; set; }
    }
}
