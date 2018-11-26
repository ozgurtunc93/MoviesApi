using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<PublisherMoviesCanli, GetMoviesHomePageDTO>()
            //    .ForMember(dest => dest., opt =>
            //      {
            //          opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            //      });

            CreateMap<PublisherMoviesCanli, GetMoviesHomePageDTO>();
            //CreateMap<City, CityForDetailDto>();;
            //CreateMap<PhotoForCreationDto,Photo>();
            //CreateMap<PhotoForReturnDto, Photo > ();
        }
    }
}
