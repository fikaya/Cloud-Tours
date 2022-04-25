using CloudTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Persistence
{
    internal class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(s => s.StationId);
            builder.Property(s => s.StationName).IsRequired().HasColumnType("varchar(150)");

            builder.HasOne(c => c.City)
                .WithMany(s => s.Stations)
                .HasForeignKey(c => c.CityId);


            builder.HasData(
                new Station() { StationId = 1, StationName = "Haydarpasa", CityId = 1 },
                new Station() { StationId = 2, StationName = "Aşti", CityId = 2 }
                );
        }
    }
}
