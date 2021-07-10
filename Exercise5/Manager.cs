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
                        if (GarageCreated) {
                            string vehicleType = VehicleTypeMenu.DisplayAndGetUserInput();

                            Handler.ParkVehicle(vehicleType);
                        }
                    
                        break;

                    case "3":
                        if (GarageCreated) { Handler.RemoveVehicle(); }
                        break;

                    case "4":
                        if (GarageCreated) { Handler.PrintGarage(); }
                        break;

                    case "9":
                        if (GarageCreated) {Handler.AddTestVehicles();}
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
                    UI.DisplayFailure("Garage has not been created yet!");
                    return false;
                }

                return true;
            }
        
        }

        private Menu CreateMainMenu()
        {
            Menu MainMenu = new Menu(UI, "Garage Management System V1.0");

            MainMenu.AddItem("1", "Create Garage");
            MainMenu.AddItem("2", "Park Vehicle");
            MainMenu.AddItem("3", "Remove Vehicle");
            MainMenu.AddItem("4", "List all parked Vehicles");
            MainMenu.AddItem("5", "Search parked Vehicles");

            MainMenu.AddEmptyLine();
            MainMenu.AddItem("9", "Add Test Data Vehicles");
            MainMenu.AddEmptyLine();
            MainMenu.AddItem("0", "Exit Application");

            return MainMenu;
        }

        private Menu CreateVehicleTypeMenu()
        {
            Menu Menu = new Menu(UI, "Select Vehicle Type");
            Menu.AddItem("1", "Car");
            Menu.AddItem("2", "Motorcyle");
            Menu.AddItem("3", "Bus");
            Menu.AddItem("4", "Boat");
            Menu.AddItem("5", "Airplane");

            return Menu;
        }
    }
}
