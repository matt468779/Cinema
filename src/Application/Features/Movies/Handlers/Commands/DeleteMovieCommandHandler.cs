using AutoMapper;
using Application.Exceptions;
using Application.Features.Movies.Requests.Commands;
using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Commands;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _unitOfWork.MovieRepository.Get(request.Id);

        if (movie == null)
            throw new NotFoundException(nameof(Movie), request.Id);

        await _unitOfWork.MovieRepository.Delete(movie);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}

