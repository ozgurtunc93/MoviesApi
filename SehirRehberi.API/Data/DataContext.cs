using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        public DbSet<CastCanli> CastCanli { get; set; }
        public DbSet<CategoryCanli> CategoryCanli { get; set; }
        public DbSet<MoviesDetailsCanli> MoviesDetailsCanli { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PublisherMovies_CastCanli> PublisherMovies_CastCanli { get; set; }
        public DbSet<PublisherMovies_CategoryCanlis> PublisherMovies_CategoryCanli { get; set; }
        public DbSet<PublisherMoviesCanli> PublisherMoviesCanli { get; set; }
        public DbSet<TopicCanli> TopicCanli { get; set; }
    }
}
