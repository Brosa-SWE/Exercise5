using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Handler
    {
        //private List<Garage>;
        private UI UI;

        public Handler(UI ui)
        {
            UI = ui;
        }

        public void CreateGarage(string name, int vehicleCapacity)
        {
            Garage Garage = new Garage(vehicleCapacity, UI);
        }


        //public void PrintGarage()
        //{
        //    UI.Write(" ");
        //    UI.Write("Garage Content");
        //    UI.Write("==============");

        //    foreach (Vehicle vehicle in Garage)
        //    {
        //        if (vehicle != null)
        //        {
        //            UI.Write(vehicle.ToString());
        //        }
        //    }

        //    UI.Write(" ");
        //    UI.Write("Press any key to contine...");
        //}

    }
}
