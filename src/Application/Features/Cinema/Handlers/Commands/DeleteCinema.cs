using AutoMapper;
using Application.Exceptions;
using Application.Features.Cinemas.Requests.Commands;
using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Commands;

public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCinemaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = await _unitOfWork.CinemaRepository.Get(request.Id);

        if (cinema == null)
            throw new NotFoundException(nameof(Movie), request.Id);

        await _unitOfWork.CinemaRepository.Delete(cinema);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}

