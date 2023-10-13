using Application.DTOs;
using Application.DTOs.Movie;
using Application.DTOs.Cinema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Movies.Requests.Queries;

public class GetMovieDetailRequest : IRequest<MovieDTO>
{
    public int Id { get; set; }
}

