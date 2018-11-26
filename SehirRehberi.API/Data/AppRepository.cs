using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<PublisherMoviesCanli> GetMovies(int Offset, int Limit)
        {
            var movies = _context.PublisherMoviesCanli.Skip(Offset).Take(Limit).OrderByDescending(y => y.Year).ThenByDescending(y => y.ImdbRating).Where(x=>x.Publisher==true).ToList();
            return movies;
        }

        public PublisherMoviesCanli GetMoviesById(int Id)
        {
            var movies = _context.PublisherMoviesCanli.Where(x => x.PublisherMovies_Id == Id).FirstOrDefault();
            if (movies!=null)
            {
                return movies;
            }
            else
                return null;
        }

        //public Photo GetPhoto(int id) 
        //{
        //    var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
        //    return photo;
        //}

        //public List<Photo> GetPhotosByCity(int cityId)
        //{
        //    var photos = _context.Photos.Where(p => p.CityId == cityId).ToList();
        //    return photos;
        //}

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

