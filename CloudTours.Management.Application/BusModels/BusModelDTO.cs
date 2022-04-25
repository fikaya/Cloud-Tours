using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application.BusModels
{
    public class BusModelDTO
    {
        public int BusModelId { get; set; }
        public string BusModelName { get; set; }
        public BusType Type { get; set; }
        public int SeatCapacity { get; set; }
        public bool HasToilet { get; set; }
        public int BusManuFacturerId { get; set; }
    }
}
