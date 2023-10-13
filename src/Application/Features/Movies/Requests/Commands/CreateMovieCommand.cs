using Application.DTOs.Movie;
using Application.DTOs.Cinema;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Movies.Requests.Commands;

public class CreateMovieCommand : IRequest<BaseCommandResponse>
{
    public MovieCreateDTO MovieDto { get; set; }
}

