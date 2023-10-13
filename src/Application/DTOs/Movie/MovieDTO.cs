using System;
using System.Collections.Generic;
using Application.DTOs.Common;

namespace Application.DTOs.Movie;

public class MovieDTO : BaseDto, IMovieDTO
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }
}
