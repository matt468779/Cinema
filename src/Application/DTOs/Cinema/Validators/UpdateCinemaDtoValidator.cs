using FluentValidation;
using Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Cinema;

namespace Application.DTOs.Cinema.Validators;

public class UpdateCinemaDtoValidator : AbstractValidator<CinemaUpdateDTO>
{

    public UpdateCinemaDtoValidator()
    {
        Include(new ICinemaDtoValidator());

    }
}

