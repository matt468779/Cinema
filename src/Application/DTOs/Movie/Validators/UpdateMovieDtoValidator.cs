using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Movie;

namespace Application.DTOs.Movie.Validators;

public class UpdateMovieDtoValidator : AbstractValidator<MovieUpdateDTO>
{
    public UpdateMovieDtoValidator()
    {
        Include(new IMovieDtoValidator());

        RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");

        RuleFor(m => m.UpdatedBy)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot exceed 100 characters.");
    }
}

