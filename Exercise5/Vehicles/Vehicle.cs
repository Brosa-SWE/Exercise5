﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Vehicle : Interfaces.IVehicle

    {
   
        public Vehicle(string regNo, string color, int noOfWheels)
        {
            RegNo = regNo;
            Color = color;
            NoOfWheels = noOfWheels;
        }

        public string RegNo { get; set; }
        public string Color { get; set; }
        public int NoOfWheels { get; set; }
    }
}