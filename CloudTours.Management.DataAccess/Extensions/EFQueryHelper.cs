using CloudTours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.DataAccess.Extensions
{
    public static class EFQueryHelper
    {
        //Dönüş tipleri ve parametreler eğer generic tipse,o generic tipler Açık değil Kapalı generic tipler olmalıdır.

        //public static IQueryable<TEntity> IncludeMultiple<TEntity>
        //    (IQueryable<TEntity> dbQuery, params string[] includings)
        //    where TEntity : class
        //{
        //    /*
        //     IQueryable=>Generic olmayan bir interface(non-generic type)
        //     IQueryable<TEntity>=>Generic açık tip bir interface(open generic type)
        //     IQueryable<Station>=>Kapatılmış bir generic(closed generic type)
        //     */

        //    if (includings != null)
        //    {
        //        //dbQuery = dbQuery.Include(s => s.City);
        //        foreach (var navProperty in includings)
        //        {
        //            dbQuery = dbQuery.Include(navProperty);
        //        }
        //    }

        //    return dbQuery;
        //}

        //Extension Metot Eklenmiş Hali

        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> dbQuery,params string[] includings)
            where TEntity:class
        {
            if (includings!=null)
            {
                foreach (var item in includings)
                {
                    dbQuery = dbQuery.Include(item);
                }
            }

            return dbQuery;
        }
    }
}
