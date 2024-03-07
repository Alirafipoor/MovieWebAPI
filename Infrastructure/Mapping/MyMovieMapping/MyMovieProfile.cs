using Application.Dto.Movie;
using AutoMapper;
using Domain.Entitties.ActorEntities;
using Domain.Entitties.DirectorEntity;
using Domain.Entitties.MovieEnttiy;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping.MyMovieMapping
{
    public class MyMovieProfile:Profile
    {
        public MyMovieProfile()
        {
            CreateMap<ActorDto, Actor>().ReverseMap();
            CreateMap<DirectorsDto, Director>().ReverseMap();

            CreateMap<AddMovieDto, MyMovie>()
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors))
                .ReverseMap();

            CreateMap<PutMovieDto,MyMovie>().ReverseMap();
        }
    }
}
