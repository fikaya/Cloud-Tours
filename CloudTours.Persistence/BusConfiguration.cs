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
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.BusId);

            builder.HasOne(b => b.BusModel)
                   .WithMany(b=>b.BusList)
                   .HasForeignKey(b => b.BusModelId);

            builder.Property(b => b.RegistrationPlate).IsRequired().HasColumnType("varchar(150)");

            builder.Property(b => b.Year).HasColumnType("int");

       

            builder.Property(b => b.SeatMapping).IsRequired().HasColumnType("int");

            builder.Property(b => b.DistanceTraveled).IsRequired().HasColumnType("int");

            builder.HasData(
                new Bus(1, 2, "34-OBS-123", 2015, SeatingType.Standart, 50000),
                new Bus(2, 3, "17-ASS-562", 2020, SeatingType.Standart, 10000),
                new Bus(3, 3, "34-OBS-123", 2013, SeatingType.Premium, 62000),
                new Bus(4, 4, "34-OBS-123", 2016, SeatingType.Premium, 2000),
                new Bus(5, 5, "34-OBS-123", 2018, SeatingType.Deluxe, 31000),
                new Bus(6, 1, "34-FBS-123", 2020, SeatingType.Deluxe, 7800),
                new Bus(7, 2, "34-OBS-123", 2013, SeatingType.Standart, 8000)
                );

        }
    }
}
