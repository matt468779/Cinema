using System;
using System.Collections.Generic;

namespace Application.DTOs.Cinema;

public interface ICinemaDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}
