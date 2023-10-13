using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence;

public interface IMovieRepository : IGenericRepository<Movie>
{
    Task<List<Movie>> GetCinemaMovies(int postId);
}

