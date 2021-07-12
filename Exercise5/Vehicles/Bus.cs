using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Bus : Vehicle
    {
        public Bus(string regNo, string color, int noOfWheels, int noOfSeats) : base(regNo, color, noOfWheels)
        {
            SpecialPropertyValue = noOfSeats.ToString();
        }

        public Bus(string regNo, string color, int noOfWheels) : base(regNo, color, noOfWheels) { }

        public override string ToString()
        {
            return base.ToString() + ($" and {SpecialPropertyValue} seats");
        }
    }
}
