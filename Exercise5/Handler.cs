using System;
using static System.Console;
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
        // enum SpecialProperties { "FuelType", " }

        public Handler(UI ui)
        {
            UI = ui;
        }

        public Garage CreateGarage()
        {
            int MaxGarageSize = 20;

            while (true)
            {
                int vehicleCapacity = UI.GetUserInputInt($"Vehicle Capacity for the new Garage (1-{MaxGarageSize}):", true, 1, MaxGarageSize);

                if (vehicleCapacity != -9999)
                {
                    Garage = new Garage(vehicleCapacity);

                    UI.DisplaySuccess($"Garage for {vehicleCapacity} vehicles created!");

                    return Garage;
                }
            }
        }

        public bool ParkVehicle(string vehicleType)
        {
            Vehicle Vehicle = null;

            string RegNo;
            string Color;
            int Wheels;
            string SpecialPropertyValue;

            while (true)
            {
                // ======================
                // Registration Number
                // ======================
                while (true)
                {
                    RegNo = UI.GetUserInputString($"Enter Registration Number for {vehicleType} or 0 to Exit to Main Menu: ", true);

                    if (RegNo == "0") { return false; }

                    if (Garage.ContainsRegNo(RegNo))
                    {
                        UI.DisplayWarning($"Registration Number {RegNo} is already parked in the Garage");
                        return false;
                    }

                    if (RegNo == "")
                    {
                        UI.DisplayFailure("You must enter a Registration Number.");
                    }
                    else
                    {
                        break;
                    }
                }

                // ======================
                // Color
                // ======================
                while (true)
                {
                    Color = UI.GetUserInputString("Enter Color: ", true);

                    if (Color == "")
                    {
                        UI.DisplayFailure("You must inout a color.");
                    }
                    else
                    {
                        break;
                    }
                }

                // ======================
                // Wheels
                // ======================
                while (true)
                {
                    Wheels = UI.GetUserInputInt("Enter no of Wheels: ", true, 0, 50);

                    if (Wheels != -9999) { break; }
                }

                // ======================
                // Create Vehicle Object
                // ======================
                 switch (vehicleType)
                {
                    case "Airplane":
                        {
                            Vehicle = new Airplane(RegNo, Color, Wheels);
                            break;
                        }
                    case "Boat":
                        {
                            Vehicle = new Boat(RegNo, Color, Wheels);
                            break;
                        }
                    case "Bus":
                        {
                            Vehicle = new Bus(RegNo, Color, Wheels);
                            break;
                        }
                    case "Car":
                        {
                            Vehicle = new Car(RegNo, Color, Wheels);
                            break;
                        }
                    case "Motorcycle":
                        {
                            Vehicle = new Motorcycle(RegNo, Color, Wheels);
                            break;
                        }
                }

                // ======================
                // Vehicle Type Unique Data
                // ======================
                while (true)
                {
                    SpecialPropertyValue = UI.GetUserInputString($"Enter {Vehicle.SpecialPropertyLabel}: ", true);

                    if (SpecialPropertyValue == "")
                    {
                        UI.DisplayFailure($"You must enter {Vehicle.SpecialPropertyLabel}.");
                    }
                    else
                    {
                        Vehicle.SpecialPropertyValue = SpecialPropertyValue;
                        break;
                    }
                }

                // ======================
                // Park Vehicle in Garage
                // ======================
                Garage.Add(Vehicle);

                UI.DisplaySuccess($"Added {Vehicle} to the Garage.");

                return true;
            }

            //return false;
        }

        internal void SearchVehicle()
        {
            throw new NotImplementedException();
        }

        internal bool RemoveVehicle(string RegNo)
        {
            string VehicleInfo = "";

            Vehicle Vehicle = Garage.GetVehicleByRegNo(RegNo);

            if (Vehicle != null)
            {
                VehicleInfo = ($"Vehicle {Vehicle} Removed from Garage");

                Garage.Remove(Vehicle);

                UI.DisplaySuccess(VehicleInfo);

                return true;
            }
            else
            {
                UI.DisplayFailure("Could not find Vehicle with RegNo " + RegNo + " to Remove");

                return false;
            }

           
        }

        public bool PrintGarage()
        {
            UI.ClearScreen();
            UI.Write(" ");

            if (Garage.IsEmpty)
            {
                UI.DisplayFailure("No vehicles are parked in the Garage.");
                return false;
            }

            UI.Write($"Garage Content (Usuage: {Garage.Count}/{Garage.VehicleCapacity})");
            UI.Write("==============================================");

            foreach (Vehicle Vehicle in Garage)
            {
                UI.Write(Vehicle?.ToString());
            }

            UI.Write(" ");
            UI.WaitForKey("Press any key to contine...");

            return true;
        }

        public bool ListVehiclesByType()
        {
            Dictionary<string, int> VehiclesByType = Garage.VehiclesByType();

            UI.ClearScreen();
            UI.Write("Vehicles by type that is parked in the Garage");
            UI.Write("=============================================");

            foreach (KeyValuePair<string, int> KeyValue in VehiclesByType)
            {
                UI.Write($"{KeyValue.Key} ({KeyValue.Value})");
            }

            UI.WaitForKey();

            return true;
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

        public void AddTestData()
        {
            string VehicleType = Randomizer.RandomVehicleType();
            string RegNo = Randomizer.RandomRegNo();
            string Color = Randomizer.RandomColor();
            string FuelType = Randomizer.RandomFuelType();
            int Wheels = int.Parse(Randomizer.RandomString("3468", 1));

            switch (VehicleType){

                case "Airplane":
                    Airplane Airplane = new Airplane(RegNo, Color, Wheels, )
                    break;

                case "Boat":

                    break;

                case "Bus":

                    break;

                case "Car":

                    break;

                case "Motorcycle":

                    break;
            }
        }

        public void AddTestVehiclesOLD()
        {
            int parkedVehicleQtyBefore = Garage.Count;

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
            if (Garage.ContainsRegNo(regNo))
            {
                UI.Write("Garage has RegNo " + regNo);
            }
            else
            {
                UI.Write("Garage does NOT have RegNo " + regNo);
            }

            regNo = "NisseGurra Aktersnurra";

            if (Garage.ContainsRegNo(regNo))
            {
                UI.Write("Garage has RegNo " + regNo);
            }
            else
            {
                UI.Write("Garage does NOT have RegNo " + regNo);
            }

            int created = Garage.Count - parkedVehicleQtyBefore;

            if (created == 0)
            {
                UI.DisplayWarning("No vehicles added to the Garage.");
            }
            else
            {
                UI.DisplaySuccess($"Created {created} vehicles in the Garage.");
            }
        }

    }
}
