using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Car : Vehicle
    {
        public Car(string regNo, string color, int noOfWheels, string fuelType) : base(regNo, color, noOfWheels)
        {
            FuelType = fuelType;
        }

        public string FuelType { get; set; }
    }
}
