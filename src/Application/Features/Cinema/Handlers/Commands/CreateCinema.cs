using AutoMapper;
using Application.DTOs.Cinema;
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
using Application.Responses;
using System.Linq;

namespace Application.Features.Cinemas.Handlers.Commands;

public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCinemaCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateCinemaDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CinemaDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Cinema creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {

            var cinema = _mapper.Map<Cinema>(request.CinemaDto);

            cinema = await _unitOfWork.CinemaRepository.Add(cinema);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = cinema.Id;
        }
        return response;
    }
}

