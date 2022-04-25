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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.CityId);
            builder.Property(x => x.CityName).IsRequired().HasColumnType("varchar(150)");

            builder.HasData(
                new City() { CityId=1,CityName="İstanbul"},
                new City() { CityId=2,CityName="Ankara"}
                );
        }
    }
}
