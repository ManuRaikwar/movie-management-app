using AutoMapper;
using MovieAccess.DataAccess.Models;
using MovieApp.Services.DTOs;

namespace MovieApp.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieCreateDto, Movie>()
                .ForMember(dest => dest.RunningTime, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.RunningTime)));

            CreateMap<MovieUpdateDto, Movie>()
                .ForMember(dest => dest.RunningTime, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.RunningTime)));
        }
    }
}
