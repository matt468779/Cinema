using Application.DTOs.Movie;
using Application.DTOs.Cinema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Movies.Requests.Commands;

public class UpdateMovieCommand : IRequest<Unit>
{
    public MovieUpdateDTO MovieDto { get; set; }
}

