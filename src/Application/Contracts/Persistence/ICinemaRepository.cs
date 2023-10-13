using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence;

public interface ICinemaRepository : IGenericRepository<Cinema>
{
    Task<List<Cinema>> GetAllCinemaMovies(int cinemaId);
}

