using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Cities
{
    // Üzerinde davranış(behaviour) olmayan, sadece veri barındıran sınıflara 
    // POCO sınıfı (plain old clr/csharp object)

    // DTO=> Data Transfer Object
    //Bir projede katmanlar arasında sadece ve sadece veri taşımak için kullanılan
    // üzerinde davranış olmayan (yani POCO cinsi) sınıflar

    // Bu proje özelinde ;DTO sınıfılarımıız Presentation <-> Appliication katmanları
    // arasında veri taşıyacak 

    //CityEntry,CityRecord,CityHeader

   public  class CitySummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
