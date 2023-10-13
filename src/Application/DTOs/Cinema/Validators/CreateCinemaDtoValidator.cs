using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Cinema;
using Application.Contracts.Persistence;

namespace Application.DTOs.Cinema.Validators;

public class CreateCinemaDtoValidator : AbstractValidator<CinemaCreateDTO>
{

    public CreateCinemaDtoValidator()
    {
        Include(new ICinemaDtoValidator());
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot exceed 100 characters.");
    }
}

