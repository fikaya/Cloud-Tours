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
    public class BusRepository : IBusRepository
    {
        private readonly CloudToursDbContext _context;

        public BusRepository(CloudToursDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Bus> GetAll(params string[] includings)
        {
            var dbQuery = _context.Buses.AsQueryable();

            dbQuery = dbQuery.IncludeMultiple(includings);

            return dbQuery.ToList();
        }
        public Bus Find(int id, params string[] includings)
        {
            var dbQuery = _context.Buses.AsQueryable();

            dbQuery = dbQuery.IncludeMultiple(includings);
            
            return dbQuery.SingleOrDefault(entity=>entity.BusId==id);
        }
   
        public void Add(Bus bus)
        {
            _context.Buses.Add(bus);
            _context.SaveChanges();
        }

        public void Remove(Bus bus)
        {
            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }

        public void Update(Bus bus)
        {
            _context.Buses.Update(bus);
            _context.SaveChanges();

        }

    }
}
