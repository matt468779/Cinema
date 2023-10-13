using AutoMapper;
using Application.DTOs.Cinema.Validators;
using Application.Exceptions;
using Application.Features.Cinemas.Requests.Commands;
using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Commands;

public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCinemaCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCinemaDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CinemaDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var cinema = await _unitOfWork.CinemaRepository.Get(request.CinemaDto.Id ?? 0);

        if (cinema is null)
            throw new NotFoundException(nameof(cinema), request.CinemaDto.Id);

        _mapper.Map(request.CinemaDto, cinema);

        await _unitOfWork.CinemaRepository.Update(cinema);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}

