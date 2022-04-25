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
    public class BusModelRepository : IBusModelRepository
    {

        private readonly CloudToursDbContext _context;

        public BusModelRepository(CloudToursDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BusModel> GetAll(params string[] includings)
        {
            var dbQuery = _context.BusModels.AsQueryable();

            dbQuery = dbQuery.IncludeMultiple(includings);

            return dbQuery.ToList();
        }

        public BusModel Find(int id, params string[] includings)
        {
            var dbQuery = _context.BusModels.AsQueryable();

            dbQuery = dbQuery.IncludeMultiple(includings);

            return dbQuery.SingleOrDefault(entity=>entity.BusModelId==id);
        }
        public void Add(BusModel model)
        {
            _context.BusModels.Add(model);
            _context.SaveChanges();
        }

        public void Remove(BusModel model)
        {
            _context.BusModels.Remove(model);
            _context.SaveChanges(true);
        }


        public void Update(BusModel model)
        {
            _context.BusModels.Update(model);
            _context.SaveChanges();
        }


    }
}
