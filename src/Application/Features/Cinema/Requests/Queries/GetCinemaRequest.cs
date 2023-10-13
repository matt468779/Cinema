using Application.DTOs;
using Application.DTOs.Cinema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Cinemas.Requests.Queries;

public class GetCinemaDetailRequest : IRequest<CinemaDTO>
{
    public int Id { get; set; }
}

