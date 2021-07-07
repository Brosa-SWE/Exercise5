using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    //Todo: Add constraint "where.... "
    internal class Garage : IEnumerable // : IGarage<IEnumerable>
    {
        private int VehicleCapacity;
        private Vehicle[] Vehicles;
        private List<string> RegNos = new List<string>();
        private UI UI;

        public Garage(int vehicleCapacity, UI ui)
        {
            VehicleCapacity = vehicleCapacity;
            Vehicles = new Vehicle[vehicleCapacity];
            UI = ui;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Add(Vehicle vehicle)
        {
            bool AddedVehicle = false;

            try
            {
                IsVehicleAllowedToBeAddedToTheGarage(vehicle);
            }
            catch (GarageException e)
            {
                UI.WriteError(e.Message);
            }

            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] == null)
                {
                    Vehicles[i] = vehicle;
                    AddedVehicle = true;
                    RegNos.Add(vehicle.RegNo);
                    break;
                }
            }

            if (AddedVehicle == true)
            {
                UI.Write($"Added {vehicle} to the Garage");
            }
 
            return AddedVehicle;
        }

        // Verify that all is Good
        private bool IsVehicleAllowedToBeAddedToTheGarage(Vehicle vehicle)
        {
            // Ensure unique Reg Nos
            if (RegNos.Contains(vehicle.RegNo))
            {
                throw new GarageException(999, ($"RegNo {vehicle.RegNo} is already in the Garage so the {vehicle.Color} {vehicle.VehicleType()} cannot be added."));
            }

            // Ensure space available in the Garage
            if (RegNos.Count == VehicleCapacity)
            {
                throw new GarageException(999, ($"The Garage is full (Max {VehicleCapacity} vehicles, so the {vehicle.Color} {vehicle.VehicleType()} {vehicle.RegNo} cannot be added."));
            }
            
            // All Good
            return true;
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
                RegNos.Remove(vehicle.RegNo);

                UI.WriteWarning($"Removed {vehicleInfo} from the Garage. The Garage now has {VehicleCapacity} vehicles left.");
            }
            else
            {
                UI.Write("");
            }

            return true;
        }

        public void PrintGarage()
        {
            UI.Write(" ");
            UI.Write("Garage Content");
            UI.Write("==============");

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle != null)
                {
                    UI.Write(vehicle.ToString());
                }
            }

            UI.Write(" ");
            UI.Write("Press any key to contine...");
        }

    }

    class GarageException : ApplicationException
    {
        public int ErrorCode;
        private string errMessage;

        public GarageException(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            errMessage = errorMessage;
        }

        public override string Message
        {
            get
            {
                return errMessage;
            }
        }

    }


}
