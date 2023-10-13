using AutoMapper;
using Application.DTOs;
using Application.DTOs.Movie;
using Application.Features.Movies.Requests.Queries;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Domain;

namespace Application.Features.Movies.Handlers.Queries;

public class GetMovieListRequestHandler : IRequestHandler<GetMovieListRequest, List<MovieDTO>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieListRequestHandler(IMovieRepository movieRepository,
            IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<List<MovieDTO>> Handle(GetMovieListRequest request, CancellationToken cancellationToken)
    {
        var movies = new List<Movie>();
        var movieDTOs = new List<MovieDTO>();

        movies = await _movieRepository.GetCinemaMovies(request.Id);
        movieDTOs = _mapper.Map<List<MovieDTO>>(movies);
        return movieDTOs;
    }
}

