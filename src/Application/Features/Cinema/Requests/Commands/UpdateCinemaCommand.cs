using Application.DTOs.Movie;
using Application.DTOs.Cinema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Cinemas.Requests.Commands;

public class UpdateCinemaCommand : IRequest<Unit>
{
    public CinemaUpdateDTO CinemaDto { get; set; }
}

