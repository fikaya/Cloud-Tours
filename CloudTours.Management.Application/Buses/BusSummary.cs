using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Buses
{
    public class BusSummary
    {
        public int BusId { get; set; }
        public string RegistrationPlate { get; set; }
        public short Year { get; set; }
        public SeatingType SeatMapping { get; set; }
        public int SeatCapacity { get; set; }
        public int SeatCount { get; set; }
        public int DistanceTraveled { get; set; }
        public string BusModelName { get; set; }
        public BusType BusModelType { get; set; }
 
    }
}
