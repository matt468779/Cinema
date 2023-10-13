using AutoMapper;
using Application.DTOs;
using Application.DTOs.Movie;
using Application.DTOs.Cinema;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        // CreateMap<Movie, MovieDTO>().ReverseMap();
        CreateMap<Movie, MovieDTO>();

        CreateMap<Movie, MovieCreateDTO>().ReverseMap();
        CreateMap<Movie, MovieUpdateDTO>().ReverseMap();

        CreateMap<Cinema, CinemaDTO>();
        CreateMap<Cinema, CinemaCreateDTO>().ReverseMap();
        CreateMap<Cinema, CinemaUpdateDTO>().ReverseMap();
    }
}

