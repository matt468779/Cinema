using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Movie;

namespace Application.DTOs.Movie.Validators;

public class CreateMovieDtoValidator : AbstractValidator<MovieCreateDTO>
{
    public CreateMovieDtoValidator()
    {
        Include(new IMovieDtoValidator());

    }
}

