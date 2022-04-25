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
    public class BusManuFacturerConfiguration : IEntityTypeConfiguration<BusManuFacturer>
    {
        public void Configure(EntityTypeBuilder<BusManuFacturer> builder)
        {
            builder.HasKey(b => b.BusManuFacturerId);
            builder.Property(b => b.Name).IsRequired().HasColumnType("varchar(150)");

            builder.HasData
                (
                new BusManuFacturer(1,"Mercedes"),
                new BusManuFacturer(2,"Man"),
                new BusManuFacturer(3,"Neoplan"),
                new BusManuFacturer(4,"Isuzu")
                );
        }
    }
}
