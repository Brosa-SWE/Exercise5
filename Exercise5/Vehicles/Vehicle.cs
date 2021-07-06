using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Vehicle : Interfaces.IVehicle

    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public int NoOfWheels { get; set; }

        public Vehicle(string regNo, string color, int noOfWheels)
        {
            RegNo = regNo;
            Color = color;
            NoOfWheels = noOfWheels;
        }

        public override string ToString()
        {
            string wheelInfo = "";

            if (NoOfWheels != 0)
            {
                wheelInfo = ($" with { NoOfWheels} wheels");
            }

            return $"{Color} {VehicleType()}{wheelInfo}";
        }

        public string VehicleType()
        {
            return this.GetType().ToString().RightBack(".");
        }
    }
}
