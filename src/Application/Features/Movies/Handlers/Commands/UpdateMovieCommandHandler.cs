using AutoMapper;
using Application.DTOs.Movie.Validators;
using Application.Exceptions;
using Application.Features.Movies.Requests.Commands;
using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Commands;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateMovieCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateMovieDtoValidator();
        var validationResult = await validator.ValidateAsync(request.MovieDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var movie = await _unitOfWork.MovieRepository.Get(request.MovieDto.Id);

        if (movie is null)
            throw new NotFoundException(nameof(movie), request.MovieDto.Id);

        _mapper.Map(request.MovieDto, movie);

        await _unitOfWork.MovieRepository.Update(movie);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}

