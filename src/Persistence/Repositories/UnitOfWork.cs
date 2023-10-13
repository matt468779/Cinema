﻿
using AutoMapper;
using Application.Contracts.Persistence;
using Application.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{

    private readonly DbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IMovieRepository _movieRepository;
    private ICinemaRepository _cinemaRepository;


    public UnitOfWork(DbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        this._httpContextAccessor = httpContextAccessor;
    }

    public IMovieRepository MovieRepository =>
        _movieRepository ??= new MovieRepository(_context);

    public ICinemaRepository CinemaRepository =>
        _cinemaRepository ??= new CinemaRepository(_context);

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

        await _context.SaveChangesAsync(username);
    }
}

