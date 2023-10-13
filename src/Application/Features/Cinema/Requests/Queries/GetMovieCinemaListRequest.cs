using Application.DTOs;
using Application.DTOs.Cinema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Cinemas.Requests.Queries;

public class GetMovieCinemaListRequest : IRequest<List<CinemaDTO>>
{
    public int MovieId { get; set; }
}

