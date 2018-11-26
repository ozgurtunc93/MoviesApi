using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SehirRehberi.API.CustomActionFilter;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    [ServiceFilter(typeof(TokenAttribute))]
    public class MoviesController : Controller
    {
        private IMemoryCache _cache;
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public MoviesController(IAppRepository appRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _appRepository = appRepository;
            _cache = memoryCache;
            _mapper = mapper;
        }
        [HttpPost("MoviestList")]
        public List<GetMoviesHomePageDTO> MoviestList([FromBody]GetMovisRequestDTO getMovisRequestDTO)
        {
            List<GetMoviesHomePageDTO> listmoviesToReturn = new List<GetMoviesHomePageDTO>();
            if (getMovisRequestDTO.Offset == 1)
            {
                var listmovies = _appRepository.GetMovies(getMovisRequestDTO.Offset - 1, getMovisRequestDTO.Limit);
                 listmoviesToReturn = _mapper.Map<List<GetMoviesHomePageDTO>>(listmovies);
            }
            else
            {
                var listmovies = _appRepository.GetMovies(getMovisRequestDTO.Offset, getMovisRequestDTO.Limit);
                listmoviesToReturn = _mapper.Map<List<GetMoviesHomePageDTO>>(listmovies);
            }
            return listmoviesToReturn;
        }
        [HttpPost("MoviestDetails")]
        public PublisherMoviesCanli MoviesDetails([FromBody]GetMovisRequestDTO getMovisRequestDTO)
        {
            var details = _appRepository.GetMoviesById(getMovisRequestDTO.Id);
            if (details != null)
            {
                return details;

            }
            else
                return null;
        }
    }
}
