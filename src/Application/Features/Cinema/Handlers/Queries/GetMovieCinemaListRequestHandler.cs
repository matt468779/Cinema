using AutoMapper;
using Application.DTOs;
using Application.DTOs.Cinema;
using Application.Features.Cinemas.Requests.Queries;
using Application.Contracts.Persistence;
using Application.Exceptions;

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Domain;

namespace Application.Features.Cinemas.Handlers.Queries;

public class GetMovieCinemaListRequestHandler : IRequestHandler<GetMovieCinemaListRequest, List<CinemaDTO>>
{
    private readonly ICinemaRepository _cinemaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetMovieCinemaListRequestHandler(ICinemaRepository cinemaRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
    {
        _cinemaRepository = cinemaRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        this._httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<CinemaDTO>> Handle(GetMovieCinemaListRequest request, CancellationToken cancellationToken)
    {
        var movie = await _unitOfWork.MovieRepository.Get(request.MovieId);

        if (movie == null)
            throw new NotFoundException(nameof(Movie), request.MovieId);

        var cinemas = new List<Cinema>();
        var cinemaDTOs = new List<CinemaDTO>();

        cinemas = await _cinemaRepository.GetAllCinemaMovies(request.MovieId);
        cinemaDTOs = _mapper.Map<List<CinemaDTO>>(cinemas);
        return cinemaDTOs;
    }
}

