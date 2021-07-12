using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Manager
    {

        private UI UI;
        Handler Handler;
        Garage Garage;

        Menu MainMenu;
        Menu VehicleTypeMenu;



        public Manager()
        {
            UI = new UI();
            Handler = new Handler(UI);

            MainMenu = CreateMainMenu();
            VehicleTypeMenu = CreateVehicleTypeMenu();
        }


        public void Run()
        {

            while (true)
            {

                string input = MainMenu.DisplayAndGetUserInput();

                switch (input)
                {
                    case "1":
                        Garage = Handler.CreateGarage();
                        break;

                    case "2":
                        if (GarageCreated && GarageHasRoom) {
                            string vehicleType = VehicleTypeMenu.DisplayAndGetUserInput();

                            Handler.ParkVehicle(vehicleType);
                        }
                        
                        break;

                    case "3":
                        if (GarageCreated && GarageHasAtLeastOneVehicleParked) 
                        {
                            Menu CurrentVehiclesMenu = CreateCurrentVehiclesMenu();
                            CurrentVehiclesMenu.UseCurrentMenuAsDictionaryForInput = true;

                            string RegNo = "";

                            string selection = CurrentVehiclesMenu.DisplayAndGetUserInput();
                            if (selection != "")
                            {
                                RegNo = selection.LeftBack(" - ");
                                Handler.RemoveVehicle(RegNo);
                            }

                        }

                        break;

                    case "4":
                        if (GarageCreated && GarageHasAtLeastOneVehicleParked) { Handler.PrintGarage(); }
                        break;

                    case "5":
                        if (GarageCreated && GarageHasAtLeastOneVehicleParked) { Handler.ListVehiclesByType(); }
                        break;

                    case "6":
                        if (GarageCreated && GarageHasAtLeastOneVehicleParked) { Handler.SearchVehicle(); }
                        break;

                    case "9":
                        if (GarageCreated) 
                        {
                            UI.ClearScreen();
                            Handler.AddTestVehicles();
                        }
                        break;

                    case "0":
                        UI.ExitApplication();
                        break;
                }
            }
        }

        private bool GarageCreated { 
            
            get
            {
                if (Garage == null)
                {
                    UI.DisplayFailure("Garage has not been created yet.");
                    return false;
                }

                return true;
            }
        
        }

        public bool GarageHasRoom {

            get 
            {
                if (Garage.IsFull)
                {
                    UI.DisplayFailure($"Garage is full (Max {Garage.VehicleCapacity} vehicles).");
                    return false;
                }

                return true;
            }
        }

        private bool GarageHasAtLeastOneVehicleParked
        {
            get
            {
                if (Garage.HasAtLeastOneVehicleParked)
                {
                    return true;
                }
                else
                {
                    UI.DisplayFailure("Garage does not have any vehicles parked.");

                    return false;
                }
            }
        }

        private Menu CreateMainMenu()
        {
            Menu MainMenu = new Menu(UI, "Garage Management System V1.0");

            MainMenu.AddItem("1", "Create Garage");
            MainMenu.AddItem("2", "Park Vehicle");
            MainMenu.AddItem("3", "Remove Vehicle");
            MainMenu.AddItem("4", "List all parked Vehicles");
            MainMenu.AddItem("5", "List Vehicles by type");
            MainMenu.AddItem("6", "Search parked Vehicles");
            MainMenu.AddEmptyLine();
            MainMenu.AddItem("9", "Add Test Data Vehicles");
            MainMenu.AddEmptyLine();
            MainMenu.AddItem("0", "Exit Application");

            return MainMenu;
        }

        private Menu CreateVehicleTypeMenu()
        {
            Menu Menu = new Menu(UI, "Select Vehicle Type");
            Menu.UseCurrentMenuAsDictionaryForInput = true;

            Menu.AddItem("1", "Car");
            Menu.AddItem("2", "Motorcycle");
            Menu.AddItem("3", "Bus");
            Menu.AddItem("4", "Boat");
            Menu.AddItem("5", "Airplane");

            return Menu;
        }

        private Menu CreateCurrentVehiclesMenu()
        {
            List<string> CurrentVehicles = new List<string>(Garage.VehiclesByRegNo());
            return GenerateMenuFromList(CurrentVehicles, "Select Vehicle to Remove from the Garage");
        }

        private Menu GenerateMenuFromList(List<string> ListOfMenuItems, string menuHeadline)
        {
            Menu Menu = new Menu(UI, menuHeadline);
            int i = 1;

            foreach (string MenuItem in ListOfMenuItems)
            {
                Menu.AddItem(i.ToString(), MenuItem);
                i++;
            }

            return Menu;
        }
    }
}
