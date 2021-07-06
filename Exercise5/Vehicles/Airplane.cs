using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.Vehicles
{
    class Airplane : Vehicle
    {

        public int NoOfEngines { get; set; }

        public Airplane(string regNo, string color, int noOfWheels, int noOfEngines) : base(regNo, color, noOfWheels)
        {
            NoOfEngines = noOfEngines;
        }

        public override string ToString()
        {
            return base.ToString() + " and " + NoOfEngines + " engines";
        }
    }
}
