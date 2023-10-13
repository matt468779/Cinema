﻿using AutoMapper;
using Application.DTOs;
using Application.DTOs.Cinema;
using Application.Features.Cinemas.Requests.Queries;
using Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Queries;

public class GetCinemaDetailRequestHandler : IRequestHandler<GetCinemaDetailRequest, CinemaDTO>
{
    private readonly ICinemaRepository _cinemaRepository;

    private readonly IMapper _mapper;

    public GetCinemaDetailRequestHandler(ICinemaRepository cinemaRepository, IMapper mapper)
    {
        _cinemaRepository = cinemaRepository;
        _mapper = mapper;
    }
    public async Task<CinemaDTO> Handle(GetCinemaDetailRequest request, CancellationToken cancellationToken)
    {
        var cinema = await _cinemaRepository.Get(request.Id);
        return _mapper.Map<CinemaDTO>(cinema);
    }
}

