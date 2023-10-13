using AutoMapper;
using Application.DTOs;
using Application.DTOs.Movie;
using Application.Features.Movies.Requests.Queries;
using Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Queries;

public class GetMovieDetailRequestHandler : IRequestHandler<GetMovieDetailRequest, MovieDTO>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieDetailRequestHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<MovieDTO> Handle(GetMovieDetailRequest request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.Get(request.Id);
        return _mapper.Map<MovieDTO>(movie);
    }
}

