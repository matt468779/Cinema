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
using Application.Responses;
using System.Linq;

namespace Application.Features.Movies.Handlers.Commands;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMovieCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateMovieDtoValidator();
        var validationResult = await validator.ValidateAsync(request.MovieDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Movie creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {

            var movie = _mapper.Map<Movie>(request.MovieDto);

            movie = await _unitOfWork.MovieRepository.Add(movie);
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = movie.Id;
        }
        return response;
    }
}

