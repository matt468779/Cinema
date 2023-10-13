using System;
using System.Collections.Generic;

namespace Application.DTOs.Movie;

public interface IMovieDTO
{
    public string? Title { get; set; }
    public string? Description { get; set; }
}
