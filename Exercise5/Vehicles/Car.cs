using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Car : Vehicle
    {
        public Car(string regNo, string color, string noOfWheels, string fuelType) : base(regNo, color, noOfWheels)
        {
            SpecialPropertyValue = fuelType;
        }
        public Car(string regNo, string color, string noOfWheels) : base(regNo, color, noOfWheels) { }

        public override string ToString()
        {
            return base.ToString() + " running on " + SpecialPropertyValue + " power";
        }

    }
}
