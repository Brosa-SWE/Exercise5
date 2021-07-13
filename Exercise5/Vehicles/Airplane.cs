using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Airplane : Vehicle
    {

        public Airplane(string regNo, string color, int noOfWheels, int noOfEngines) : base(regNo, color, noOfWheels)
        {
            SpecialPropertyValue = noOfEngines.ToString();
        }

        public Airplane(string regNo, string color, int noOfWheels) : base(regNo, color, noOfWheels)
        {
           
        }

        public override string ToString()
        {
            return base.ToString() + " and " + SpecialPropertyValue + " engines";
        }
    }
}
