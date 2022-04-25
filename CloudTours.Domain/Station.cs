using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Domain
{
    public class Station
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
