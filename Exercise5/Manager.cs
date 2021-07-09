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
        

        public Manager()
        {
            UI = new UI();
            Handler = new Handler(UI);
            Garage = Handler.CreateGarage("Elefanten", 9);
        }


        public void Run()
        {
            MainMenu = CreateMainMenu();
            string input = MainMenu.DisplayAndGetUserInput();

            switch (input)
            {
                case "1":
                    Handler.CreateGarage();
                    break;

                case "2":

                    break;

                case "3":
                    Handler.PrintGarage();
                    break;

                case "9":
                    Handler.AddTestVehicles();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }
        }

        private Menu CreateMainMenu()
        {
            Menu MainMenu = new Menu(UI, "Garage Management System V1.0");

            MainMenu.AddItem("1", "Create Garage");
            MainMenu.AddItem("2", "Park Vehicle");
            MainMenu.AddItem("3", "Remove Vehicle");
            MainMenu.AddItem("4", "Search/List parked Vehicles");
            MainMenu.AddEmptyLine();
            MainMenu.AddItem("9", "Add Test Data Vehicles");
            MainMenu.AddEmptyLine();
            MainMenu.AddItem("0", "Exit Application");

            return MainMenu;
        }
 


    }
}
