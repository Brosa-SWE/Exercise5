using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise5.Vehicles;
using static Exercise5.Delegates;

namespace Exercise5
{
    class Handler
    {
        private Garage Garage;
        private static UI UI;

        public Handler(UI ui)
        {
            UI = ui;
        }

        public Garage CreateGarage(string name, int vehicleCapacity)
        {
            Garage = new Garage(vehicleCapacity);

            return Garage;
        }

         public void PrintGarage()
        {
            UI.Write(" ");
            UI.Write($"Garage Content (Usuage: {Garage.Count}/{Garage.VehicleCapacity})");
            UI.Write("==============================================");

            foreach (Vehicle Vehicle in Garage)
            {
                if (Garage != null)
                {
                    UI.Write(Vehicle.ToString());
                }
            }

            UI.Write(" ");
            UI.Write("Press any key to contine...");
        }

        public bool Add(Vehicle vehicle)
        {
            if (Garage.Add(vehicle))
            {
                UI.Write($"Added {vehicle} to the Garage");
                return true;
            }
            else
            {
                UI.WriteWarning($"{vehicle} NOT added to the Garage");
                return false;
            }
        }

        public bool Remove(Vehicle vehicle)
        {
            if (Garage.Remove(vehicle))
            {
                UI.WriteWarning($"Removed {vehicle} from the Garage. The Garage now has {Garage.Count} vehicles left.");
                return true;
            }
            else
            {
                UI.WriteError($"{vehicle} to be removed was not found in the Garage.");
                return false;
            }
        }

        public void AddTestVehicles()
        {
            Car car = new Car("ABC 123", "Red", 4, "Electric");
            Add(car);

            Airplane airplane = new Airplane("N628TS", "White", 6, 2);
            Add(airplane);

            Motorcycle mc = new Motorcycle("Hej 999", "Green", 2, 1000);
            Add(mc);

            Bus bus = new Bus("LED 947", "Red", 6, 65);
            Add(bus);

            Boat boat = new Boat("Gh67", "White", 0, 27);
            Add(boat);

            // Second set

            car = new Car("ABC 123", "Yellow", 4, "Diesel");
            Add(car);

            airplane = new Airplane("J654SE", "Grey", 3, 1);
            Add(airplane);

            // Remove something
            Remove(boat);

            mc = new Motorcycle("Hayabusa", "Black", 2, 1340);
            Add(mc);

            new Bus("DFG 046", "Blue", 6, 120);
            Add(bus);

            boat = new Boat("JYF67", "White", 0, 5);
            Add(boat);

            string regNo = "JYF67";
            if (Garage.HasRegNo(regNo))
            {
                Console.WriteLine("Garage has RegNo " + regNo);
            }
            else
            {
                Console.WriteLine("Garage does NOT have RegNo "+ regNo);
            }

            regNo = "NisseGurra Aktersnurra";

            if (Garage.HasRegNo(regNo))
            {
                Console.WriteLine("Garage has RegNo " + regNo);
            }
            else
            {
                Console.WriteLine("Garage does NOT have RegNo " + regNo);
            }

        }

    }
}
