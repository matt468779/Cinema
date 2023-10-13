using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Movie;

namespace Application.DTOs.Movie.Validators;

public class IMovieDtoValidator : AbstractValidator<IMovieDTO>
{
    public IMovieDtoValidator()
    {
        RuleFor(m => m.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.");
    }
}

