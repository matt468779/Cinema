using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations.Entities;
public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.HasData(
              new Cinema
              {
                  Id = 1,
                  Title = "Software",
                  Content = "Software Development",
                  CreatedBy = "Admin",
                  LastModifiedBy = "Admin"
              },
              new Cinema
              {
                  Id = 2,
                  Title = "Backend",
                  Content = "Backend Server Development",
                  CreatedBy = "Admin",
                  LastModifiedBy = "Admin"

              },
              new Cinema
              {
                  Id = 3,
                  Title = "Web",
                  Content = "Web App Development",
                  CreatedBy = "Admin",
                  LastModifiedBy = "Admin"

              },
              new Cinema
              {
                  Id = 4,
                  Title = "Mobile",
                  Content = "Mobile App Development",
                  CreatedBy = "Admin",
                  LastModifiedBy = "Admin"
              }
          );
    }
}

