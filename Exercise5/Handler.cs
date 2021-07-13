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
            int MaxGarageSize = 250;

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
        }

        internal void SearchVehicleByRegNo()
        {
            ConsoleKeyInfo Input;
            StringBuilder sb = new StringBuilder();
            List<string> MatchingRegNos = new List<string>();
            
            do
            {
                string CustomPrompt = "Search for RegNo (End Search with Enter): " + sb.ToString();

                UI.ClearScreen();
                UI.Write(CustomPrompt);
                UI.Write(" ");
                UI.WriteList(MatchingRegNos);
                UI.Write(" ");

                UI.SetCursorPosition(CustomPrompt.Length, 0);

                Input = UI.ReadKey(false);
                if (Input.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
                else
                {
                    sb.Append(Input.KeyChar);
                }

                string RegNoInput = sb.ToString();

                MatchingRegNos = Garage.GetVehiclesMatchingRegNo(RegNoInput);

                UI.WriteList(MatchingRegNos);
 
            } 
            while (Input.Key != ConsoleKey.Enter);

        }

        internal bool SearchVehicleByProperties()
        {
            Menu Menu;
            List<string> Values;
            StringBuilder sb = new StringBuilder();
            sb.Append("Search for all ");

            while (true)
            {
                Values = Garage.GetUniqueVehicleColors();

                Menu = new Menu(UI, "Select Vehicle Types");
                
                UI.ClearScreen();
                UI.Write(sb.ToString());

                
            }
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

        public Garage CreateTestGarage()
        {
            int NoOfVehiclesToCreate = 250;

            Garage = new Garage(NoOfVehiclesToCreate);

            CreateRandomVehiclesInGarage(NoOfVehiclesToCreate);

            return Garage;
        }


        public void AddTestData()
        {
 

            while (true)
            {
                UI.ClearScreen();
                UI.Write($"Enter number of Test Vehicles to create (1-{Garage.FreeSpaces}), or 0 to exit to Main Menu.");

                int parkedVehicleQtyBefore = Garage.Count;

                int NoOfVehiclesToCreate = UI.GetUserInputInt(0, Garage.FreeSpaces);

                if (NoOfVehiclesToCreate == 0) { return; }

                CreateRandomVehiclesInGarage(NoOfVehiclesToCreate);

                int created = Garage.Count - parkedVehicleQtyBefore;

                if (created == 0)
                {
                    UI.DisplayWarning("No vehicles added to the Garage.");
                }
                else
                {
                    UI.DisplaySuccess($"Created {created} vehicles in the Garage.");
                }

                return;
            }
        }

        private void CreateRandomVehiclesInGarage(int NoOfVehiclesToCreate)
        {
            string VehicleType;
            string RegNo;
            string Color;
            string SpecialValue;
            int Wheels;
            Vehicle Vehicle = null;

            for (int j = 0; j < NoOfVehiclesToCreate; j++)
            {
                VehicleType = Randomizer.RandomVehicleType();
                RegNo = Randomizer.RandomRegNo();
                Color = Randomizer.RandomColor();
                SpecialValue = Randomizer.RandomSpecialValue(VehicleType);

                switch (VehicleType)
                {

                    case "Airplane":
                        Wheels = 6;
                        Vehicle = new Airplane(RegNo, Color, Wheels, int.Parse(SpecialValue));
                        break;

                    case "Boat":
                        Wheels = 0;
                        Vehicle = new Boat(RegNo, Color, Wheels, int.Parse(SpecialValue));
                        break;

                    case "Bus":
                        Wheels = 8;
                        Vehicle = new Bus(RegNo, Color, Wheels, int.Parse(SpecialValue));
                        break;

                    case "Car":
                        Wheels = 4;
                        Vehicle = new Car(RegNo, Color, Wheels, SpecialValue);
                        break;

                    case "Motorcycle":
                        Wheels = 2;
                        Vehicle = new Motorcycle(RegNo, Color, Wheels, int.Parse(SpecialValue));
                        break;
                }

                Garage.Add(Vehicle);

            }
        }

    }
}
