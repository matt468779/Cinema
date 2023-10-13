using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.Configurations;
using System.Collections.Generic;
using System.Text;

namespace Identity;

public class CinemaAppIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public CinemaAppIdentityDbContext(DbContextOptions<CinemaAppIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }
}

