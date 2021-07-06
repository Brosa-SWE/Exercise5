using Exercise5.Vehicles;
using System;
using System.Collections;

namespace Exercise5
{
    class Program
    {
        public UI UI = new UI();
        public Garage<IEnumerable> Garage;

        static void Main(string[] args)
        {
            Garage<IEnumerable> = CreateGarage(10);

            // addTestVehicles(Garage);

            // Garage.PrintGarage();

            Console.ReadKey();

        }

        public Garage<IEnumerable> CreateGarage(int forNoOfCars)
        {
            Garage<IEnumerable> Garage = new Garage<IEnumerable>(forNoOfCars, UI);

            return Garage;
        }
            
        private void AddTestVehicles(Garage<IEnumerable> Garage)
        {
            Car car = new Car("ABC 123", "Red", 4, "Electric");
            Garage.AddVehicle(car);

            Airplane airplane = new Airplane("N628TS", "White", 6, 2);
            Garage.AddVehicle(airplane);

            Motorcycle mc = new Motorcycle("Hej 999", "Green", 2, 1000);
            Garage.AddVehicle(mc);

            Bus bus = new Bus("LED 147", "Red", 6, 65);
            Garage.AddVehicle(bus);

            Boat boat = new Boat("Gh67", "White", 0, 27);
            Garage.AddVehicle(boat);

        }
    }
}
