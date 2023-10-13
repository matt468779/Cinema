using System;
using System.Collections.Generic;
using Application.DTOs.Movie;
using Application.DTOs.Common;

namespace Application.DTOs.Cinema;

public class CinemaDTO : BaseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }

}

