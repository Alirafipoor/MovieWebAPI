using Domain.Entitties.MovieEnttiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entitconfiguration
{
    public class MyMovieConfiguration : IEntityTypeConfiguration<MyMovie>
    {
        public void Configure(EntityTypeBuilder<MyMovie> builder)
        {
            builder.Property(p=>p.Title).IsRequired().HasMaxLength(50);

            builder.Property(p=>p.Year).IsRequired();

            builder.Property(p=>p.GenreId).IsRequired();
        }
    }
}
