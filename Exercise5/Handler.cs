using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise5.Vehicles;

namespace Exercise5
{
    class Handler
    {
        private List<Garage> Garages = new List<Garage>();
        private static UI UI = new UI();

        public Handler()
        {
          
        }

        public Garage CreateGarage(string name, int vehicleCapacity)
        {
            Garage Garage = new Garage(vehicleCapacity);
            Garages.Add(Garage);

            Garage.onCarAdded = UiWrite;
            return Garage;
        }

        private void UiWrite(object sender, GarageEventArgs args)
        {
            UI.Write(args.Message);
        }

        public void PrintGarage(Garage Garage)
        {
            UI.Write(" ");
            UI.Write("Garage Content");
            UI.Write("==============");

            //foreach (Vehicle Vehicle in Garage.Vehicles)
            //{
            //    if (Garage != null)
            //    {
            //        UI.Write(Garage.ToString());
            //    }
            //}

            UI.Write(" ");
            UI.Write("Press any key to contine...");
        }

        public void AddTestVehicles(Garage Garage)
        {
            Car car = new Car("ABC 123", "Red", 4, "Electric");
            Garage.Add(car);

            Airplane airplane = new Airplane("N628TS", "White", 6, 2);
            Garage.Add(airplane);

            Motorcycle mc = new Motorcycle("Hej 999", "Green", 2, 1000);
            Garage.Add(mc);

            Bus bus = new Bus("LED 947", "Red", 6, 65);
            Garage.Add(bus);

            Boat boat = new Boat("Gh67", "White", 0, 27);
            Garage.Add(boat);

            // Second set

            car = new Car("ABC 123", "Yellow", 4, "Diesel");
            Garage.Add(car);

            airplane = new Airplane("J654SE", "Grey", 3, 1);
            Garage.Add(airplane);

            mc = new Motorcycle("Hayabusa", "Black", 2, 1340);
            Garage.Add(mc);

            new Bus("DFG 046", "Blue", 6, 120);
            Garage.Add(bus);

            boat = new Boat("JYF67", "White", 0, 5);
            Garage.Add(boat);

        }

    }
}
