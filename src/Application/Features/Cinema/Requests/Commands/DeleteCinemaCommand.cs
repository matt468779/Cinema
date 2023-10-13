using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Cinemas.Requests.Commands;

public class DeleteCinemaCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
