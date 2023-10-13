using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Movies.Requests.Commands;

public class DeleteMovieCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
