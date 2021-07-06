using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Bus : Vehicle
    {
        public int NoOfSeats { get; set; }

        public Bus(string regNo, string color, int noOfWheels, int noOfSeats) : base(regNo, color, noOfWheels)
        {
            NoOfSeats = noOfSeats;
        }

        public override string ToString()
        {
            return base.ToString() + " and " + NoOfSeats + " seats";
        }
    }
}
