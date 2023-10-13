using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Cinema;

namespace Application.DTOs.Cinema.Validators;

public class ICinemaDtoValidator : AbstractValidator<ICinemaDTO>
{

    public ICinemaDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

    }
}

