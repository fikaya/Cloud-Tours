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
    public class BusModelConfiguration : IEntityTypeConfiguration<BusModel>
    {
        public void Configure(EntityTypeBuilder<BusModel> builder)
        {
            builder.HasKey(b => b.BusModelId);

            builder.Property(b => b.BusModelName).IsRequired().HasColumnType("varchar(150)");

            builder.HasOne(x => x.BusManuFacturer)
                   .WithMany(x=>x.BusModels).HasForeignKey(x => x.BusManuFacturerId);
               
            builder.Property(x => x.Type).HasColumnType("int");
            builder.Property(x => x.SeatCapacity).HasColumnType("int");
            builder.Property(x => x.HasToilet).IsRequired();

            builder.HasData(

                 new BusModel(1, "Mercedess Travego2", BusType.Coach, 44, true, 1),
                 new BusModel(2, "Man-Fortuna", BusType.None, 0, true, 2),
                 new BusModel(3, "Mercedess Travego1", BusType.Coach, 44, false, 1),
                 new BusModel(4, "Starliner", BusType.Coach, 44, true, 3),
                 new BusModel(5, "Man-Lions", BusType.Shuttle, 26, true, 2),
                 new BusModel(6, "Citibus", BusType.Coach, 44, true, 4),
                 new BusModel(7, "Citimark", BusType.Coach, 52, false, 4),
                 new BusModel(8, "Novociti", BusType.Coach, 48, true, 4));
        }
    }
}
