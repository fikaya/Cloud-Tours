using CloudTours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Persistence
{
    public class CloudToursDbContext : DbContext
    {
        private const string context = "Server=.; Database=Db_CloudTours; Integrated Security=true;";

        public DbSet<City> Cities { get; set; }
        public DbSet<Station> Stations  { get; set; }
        public DbSet<BusModel> BusModels { get; set; }
        public DbSet<BusManuFacturer> BusManuFacturers { get; set; }
        public DbSet<Bus> Buses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(context);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new StationConfiguration());
            modelBuilder.ApplyConfiguration(new BusModelConfiguration());
            modelBuilder.ApplyConfiguration(new BusManuFacturerConfiguration());
            modelBuilder.ApplyConfiguration(new BusConfiguration());
        }
    }
}
