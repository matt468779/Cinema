using Application.DTOs.Cinema;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Cinemas.Requests.Commands;

public class CreateCinemaCommand : IRequest<BaseCommandResponse>
{
    public CinemaCreateDTO CinemaDto { get; set; }
}

