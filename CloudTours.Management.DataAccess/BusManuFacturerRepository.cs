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
    public class BusManuFacturerRepository : IBusManuFacturerRepository
    {
        private readonly CloudToursDbContext _context;

        public BusManuFacturerRepository(CloudToursDbContext cloudToursDbContext)
        {
            _context = cloudToursDbContext;
        }

        public IEnumerable<BusManuFacturer> GetAll(params string[] includings)
        {
            var dbQuery = _context.BusManuFacturers.AsQueryable();
            dbQuery = dbQuery.IncludeMultiple(includings);
            return dbQuery;
        }

        public BusManuFacturer Find(int id,params string[] includings)
        {
            var dbQuery = _context.BusManuFacturers.AsQueryable();
            dbQuery = dbQuery.IncludeMultiple(includings);
            return dbQuery.SingleOrDefault(entiy=>entiy.BusManuFacturerId==id);
        }
        public void Add(BusManuFacturer busManuFacturer)
        {
            _context.BusManuFacturers.Add(busManuFacturer);
            _context.SaveChanges();
        }

        public void Remove(BusManuFacturer busManuFacturer)
        {
            _context.BusManuFacturers.Remove(busManuFacturer);
            _context.SaveChanges();

        }

        public void Update(BusManuFacturer busManuFacturer)
        {
            _context.Update(busManuFacturer);
            _context.SaveChanges();
        }
      
    }
}
