using System;
using System.Collections.Generic;
using Application.DTOs.Common;

namespace Application.DTOs.Cinema;

public class CinemaUpdateDTO : BaseDto, ICinemaDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Capacity { get; set; }
}

