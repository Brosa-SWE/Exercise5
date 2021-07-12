using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public static class Randomizer
    {
        private static Random random = new Random();
        public static string RandomString(string source, int length)
        {
            // const string chars = "ABCDEFGHJKLMNOPRSTUWXYZ0123456789";
            return new string(Enumerable.Repeat(source, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomRegNo()
        {
            string Letters = RandomString("ABCDEFGHJKLMNOPRSTUWXYZ", 3);
            string Numbers = RandomString("0123456789", 3);

            return Letters + Numbers;
        }

        public static string RandomVehicleType()
        {
            Dictionary<string, string> VehicleTypes = new Dictionary<string, string>();
            VehicleTypes.Add("1", "Car");
            VehicleTypes.Add("2", "Motorcycle");
            VehicleTypes.Add("3", "Bus");
            VehicleTypes.Add("4", "Boat");
            VehicleTypes.Add("5", "Airplane");

            return VehicleTypes[RandomString("12345", 1)];
        }

        public static string RandomColor()
        {
            Dictionary<string, string> Colors = new Dictionary<string, string>();
            Colors.Add("1", "Gul");
            Colors.Add("2", "Röd");
            Colors.Add("3", "Blå");
            Colors.Add("4", "Grön");
            Colors.Add("5", "Vit");
            Colors.Add("6", "Svart");
            Colors.Add("7", "Silver");
            Colors.Add("8", "Orange");
            Colors.Add("9", "Brun");
            Colors.Add("0", "Grå");

            return Colors[RandomString("0123456789", 1)];

        }

        public static string RandomFuelType()
        {
            Dictionary<string, string> FuelTypes = new Dictionary<string, string>();
            FuelTypes.Add("1", "Bensin");
            FuelTypes.Add("2", "Diesel");
            FuelTypes.Add("3", "Etanol");
            FuelTypes.Add("4", "Electric");

            return FuelTypes[RandomString("1234", 1)];

        }
    }
}
