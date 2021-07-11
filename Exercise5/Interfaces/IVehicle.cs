using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Interfaces
{
    interface IVehicle
    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public int NoOfWheels { get; set; }
        public string VehicleSpecificLabel { get; set; }
        public string VehicleSpecificValue { get; set; }
    }
}
