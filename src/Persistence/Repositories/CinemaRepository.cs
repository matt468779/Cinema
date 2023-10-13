kusing Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
{
    private readonly DbContext _dbContext;

    public CinemaRepository(DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Cinema>> GetAllCinemaMovies(int movieId)
    {
        var cinemas = await _dbContext.Cinemas.Where(q => q.Movieid == movieId)
            .ToListAsync();
        return cinemas;
    }

}

