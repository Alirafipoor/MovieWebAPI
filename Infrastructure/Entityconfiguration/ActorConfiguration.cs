using Domain.Entitties.ActorEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entitconfiguration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(50);

            builder.Property(p => p.Age).IsRequired();

            builder.Property(p=>p.Award).IsRequired();

            builder.Property(p=>p.IsMarried).IsRequired().HasDefaultValue(false);

            builder.Property(p=>p.Birthday).IsRequired();

            builder.Property(p=>p.Description).IsRequired().HasMaxLength(500);

        }
    }
}
