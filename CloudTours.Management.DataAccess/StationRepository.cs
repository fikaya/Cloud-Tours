using CloudTours.Domain;
using CloudTours.Management.Application.Repositories;
using CloudTours.Management.DataAccess.Extensions;
using CloudTours.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.DataAccess
{
    public class StationRepository : IStationRepository
    {
        private readonly CloudToursDbContext _context;

        public StationRepository(CloudToursDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Station> GetAll(params string[] includings)
        {
            var dbQuery = _context.Stations.AsQueryable();

            //Düz Yazdığımız Koşul

            //if (includings != null)
            //{
            //    foreach (var navProperty in includings)
            //    {
            //        dbQuery = dbQuery.Include("City");
            //    }
            //}

            //return dbQuery;

            ///////////////////////////////////////---------

            //Metotla yaptığımız
            //dbQuery = EFQueryHelper.IncludeMultiple(dbQuery, includings);
            //return dbQuery.ToList();

            ///////////////////////////////////////---------

            dbQuery = dbQuery.IncludeMultiple(includings);

            return dbQuery.ToList();
        }

        public Station Find(int id, params string[] includings)
        {
            var dbQuery = _context.Stations.AsQueryable();
                            //from n _context.Station
                            //select n

            dbQuery = dbQuery.IncludeMultiple(includings);

            return dbQuery.SingleOrDefault(entity=>entity.StationId==id);
        }
        public void Add(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
        }

        public void Remove(Station station)
        {
            _context.Stations.Remove(station);
            _context.SaveChanges();
        }

        public void Update(Station station)
        {
            _context.Stations.Update(station);
            _context.SaveChanges();
        }
    }
}
