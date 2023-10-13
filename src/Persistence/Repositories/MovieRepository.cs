using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    private readonly DbContext _dbContext;

    public MovieRepository(DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Movie>> GetCinemaMovies(int id)
    {

        return _dbContext.Movies.Include(m => m.Cinemas).ToList();
    }
}

