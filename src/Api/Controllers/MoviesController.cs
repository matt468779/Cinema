using Application.DTOs.Movie;
using Application.Features.Movies.Requests.Commands;
using Application.Features.Movies.Requests.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<MoviesController>
    [HttpGet]
    public async Task<ActionResult<List<MovieDTO>>> Get(bool isLoggedInUser = false)
    {
        var movies = await _mediator.Send(new GetCinemaMovieListRequest() { });
        return Ok(movies);
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDTO>> Get(int id)
    {
        var movie = await _mediator.Send(new GetMovieDetailRequest { Id = id });
        return Ok(movie);
    }

    // POST api/<MoviesController>
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Cinema([FromBody] MovieCreateDTO movie)
    {
        var command = new CreateMovieCommand { MovieDto = movie };
        var repsonse = await _mediator.Send(command);
        return Ok(repsonse);
    }



    // GET api/<MoviesController>/cinemas/5
    [HttpGet("cinemas/{id}")]
    public async Task<ActionResult> GetCinemaMovies(int id)
    {
        var command = new GetCinemaMovieListRequest { CinemaId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMovieCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

