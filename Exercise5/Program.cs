using Exercise5.Vehicles;
using System;
using System.Collections;

namespace Exercise5
{
    class Program
    {
        public static UI UI = new UI();
        
        static void Main(string[] args)
        {
            Garage Garage = CreateGarage(9);

            AddTestVehicles(Garage);

            Garage.PrintGarage();

            Console.ReadKey();

        }

        public static Garage CreateGarage(int forNoOfCars)
        {
            Garage Garage = new Garage(forNoOfCars, UI);

            return Garage;
        }
            
        private static void AddTestVehicles(Garage Garage)
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
