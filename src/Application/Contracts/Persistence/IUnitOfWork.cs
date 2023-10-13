using System;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    ICinemaRepository CinemaRepository { get; }
    IMovieRepository MovieRepository { get; }
    Task Save();
}

