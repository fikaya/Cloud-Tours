using CloudTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Repositories
{
    public interface ICityRepository:IRepository<City>
    {
       //Bir interface bir interface i burada inherit etmiştir.
    }
}
