using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.Buses
{
    public class BusDTO
    {
        public int BusId { get; set; }
        public string RegistrationPlate { get; set; }
        public short Year { get; set; }
        public SeatingType SeatMapping { get; set; }  //Enum titpinde kullanılacak
        public int DistanceTraveled { get; set; }
        public int BusModelId { get; set; }
    }
}
