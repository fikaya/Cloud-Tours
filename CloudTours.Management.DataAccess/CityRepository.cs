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
    public class CityRepository : ICityRepository
    {
       private readonly CloudToursDbContext _context;

        public CityRepository(CloudToursDbContext context)
        {
            _context = context;
        }

        public City Find(int id, params string[] includings)
        {
            //Explicit Loading

            //var city = _context.Cities.Find(id);

            //if (city != null && includings != null)
            //{
            //    foreach (var item in includings)
            //    {
            //        _context.Entry(city).Reference(item).Load();
            //    }
            //}

            //Eager Loading

            var dbQuery = _context.Cities.AsQueryable();

            //if (includings!=null)
            //{
            //    foreach (var navProp in includings)
            //    {
            //        dbQuery = dbQuery.Include(navProp);
            //    }
            //}
            //return dbQuery.SingleOrDefault(e => e.CityId == id);

            dbQuery = dbQuery.IncludeMultiple(includings);

            return dbQuery.SingleOrDefault(e => e.CityId == id);
        }
        public IEnumerable<City> GetAll(params string[] includings)
        {
            var dbQuery = _context.Cities.AsQueryable();
           
            //Düz Yazdığımız Koşul

            //if (includings!=null)
            //{
            //    foreach (var navProperty in includings)
            //    {
            //        dbQuery = dbQuery.Include(navProperty);
            //    }
            //}

            //return dbQuery;


            ///////////////////////////////////////---------

            //Metotla yaptığımız
            //dbQuery = EFQueryHelper.IncludeMultiple(dbQuery, includings);
            //return dbQuery.ToList();

            ///////////////////////////////////////---------

            //Extensions Metot
             dbQuery = dbQuery.IncludeMultiple(includings);
            //Instance metot olarak çağırıyoruz(Normalde yukarıdaki gibi çağırıyorduk)
            return dbQuery.ToList();

        }
        public void Add(City city)
        {
            _context.Add(city);
            _context.SaveChanges();
        }
        public void Remove(City city)
        {
            _context.Remove(city);
            _context.SaveChanges();
        }
        public void Update(City city)
        {
            _context.Update(city);
            _context.SaveChanges();
        }

      
    }
}
