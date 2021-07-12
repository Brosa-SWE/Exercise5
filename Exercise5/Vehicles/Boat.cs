using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Boat : Vehicle
    {
        public Boat(string regNo, string color, int noOfWheels, int length) : base(regNo, color, noOfWheels)
        {
            SpecialPropertyValue = length.ToString();
        }
        public Boat(string regNo, string color, int noOfWheels) : base(regNo, color, noOfWheels) { }

        public override string ToString()
        {
            return base.ToString() + " that is " + SpecialPropertyLabel + " meters long";
        }
    }
}
