using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Motorcycle : Vehicle
    {
        public Motorcycle(string regNo, string color, string noOfWheels, int cylinderVolume) : base(regNo, color, noOfWheels)
        {
            SpecialPropertyValue = cylinderVolume.ToString();
        }

        public Motorcycle(string regNo, string color, string noOfWheels) : base(regNo, color, noOfWheels) { }


        public override string ToString()
        {
            return base.ToString() + " and " + SpecialPropertyValue + " cc";
        }
    }
}
