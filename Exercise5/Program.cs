using System;
using System.Collections;

namespace Exercise5
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            Handler Handler = new Handler();
            Garage Garage = Handler.CreateGarage("Elefanten", 9);

            Handler.AddTestVehicles(Garage);

            Handler.PrintGarage(Garage);

            Console.ReadKey();

        }


    }
}
