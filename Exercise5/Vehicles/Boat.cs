using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Boat : Vehicle
    {
        public int Length { get; set; }

        public Boat(string regNo, string color, int noOfWheels, int length) : base(regNo, color, noOfWheels)
        {
            Length = length;
        }

        public override string ToString()
        {
            return base.ToString() + " that is " + Length + " meters long";
        }
    }
}
