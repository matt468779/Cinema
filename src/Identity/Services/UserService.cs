﻿using AutoMapper;
using Application.Contracts.Identity;
using Application.Models.Identity;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> GetUser(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);
        return new User
        {
            Email = employee.Email,
            Id = employee.Id,
            Firstname = employee.FirstName,
            Lastname = employee.LastName
        };
    }

    public async Task<List<User>> GetUsers()
    {
        var employees = await _userManager.GetUsersInRoleAsync("User");
        return employees.Select(q => new User { 
            Id = q.Id,
            Email = q.Email,
            Firstname = q.FirstName,
            Lastname = q.LastName
        }).ToList();
    }
}

