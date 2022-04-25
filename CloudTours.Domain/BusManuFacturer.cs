using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Domain
{
    public class BusManuFacturer
    {
        public BusManuFacturer(int busManuFacturerId, string name)
        {
            BusManuFacturerId = busManuFacturerId;
            Name = name;
        }

        public int BusManuFacturerId { get; set; }
        public string Name { get; set; }
        public ICollection<BusModel> BusModels { get; set; }
    }
}
