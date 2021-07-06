using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{   
    //Todo: Add constraint "where.... "
    internal class Garage<IEnumberable> : IGarage<IEnumerable>
    {
        private int GarageSize;
        private Vehicle[] Vehicles;
        private UI UI;

        public Garage(int noOfVehicles, UI ui)
        {
            GarageSize = noOfVehicles;
            Vehicles = new Vehicle[noOfVehicles];
            UI = ui;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Length < GarageSize)
            {
                Vehicles.Append(vehicle);
                UI.Write("Added " + vehicle + " to the Garage");
                return true;
            }
            else
            {
                UI.Write($"Could not add {vehicle} to the Garage, it's full (Max {GarageSize} vehicles)");
                return false;
            }
        }

        public bool RemoveVehicle(Vehicle vehicle)
        {
            int foundIndex = 0;
            bool foundVehicle = false;
            string vehicleInfo = vehicle.ToString();

            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] == vehicle)
                {
                    foundIndex = i;
                    foundVehicle = true;
                    break;
                }
            }

            if (foundVehicle)
            {
                Vehicles = Vehicles.Where((source, index) => index != foundIndex).ToArray();
                UI.Write($"Removed {vehicleInfo} from the Garage. The Garage now has {GarageSize} vehicles left.");
            }
            else
            {
                UI.Write("");
            }

            return true;
        }

        public void PrintGarage()
        {
            foreach (Vehicle vehicle in Vehicles) {
                UI.Write(vehicle.ToString());
            }
        }
 
    }
}
