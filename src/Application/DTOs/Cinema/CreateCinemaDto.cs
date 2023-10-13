using System;
using System.Collections.Generic;

namespace Application.DTOs.Cinema;

public class CinemaCreateDTO : ICinemaDTO
{
    public int? Id {get; set;}
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Capacity { get; set; }
}

