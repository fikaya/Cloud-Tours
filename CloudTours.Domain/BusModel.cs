using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Domain
{
    public class BusModel
    {
        public BusModel(int busModelId, string busModelName, BusType type, int seatCapacity, bool hasToilet, int busManuFacturerId)
        {
            BusModelId = busModelId;
            BusModelName = busModelName;
            Type = type;
            SeatCapacity = seatCapacity;
            HasToilet = hasToilet;
            BusManuFacturerId = busManuFacturerId;
        }
        //Delete icin uzun uzun constructor doldurmamak ıcın bunu ekstradan yazdık
        public BusModel(int busModelId)
        {
            BusModelId = busModelId;
        }
       

        public int BusModelId { get; set; }
        public string BusModelName { get; set; }
        public BusType Type { get; }
        public int SeatCapacity { get; }
        public bool HasToilet { get; }
        public int BusManuFacturerId { get; } //Navigaciton Property
        public BusManuFacturer BusManuFacturer { get; set; }
        public ICollection<Bus> BusList { get; set; }


    }
}
