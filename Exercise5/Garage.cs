using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Exercise5.Delegates;

namespace Exercise5
{
    //Todo: Add constraint "where.... "
    //Todo: Change to IEnumerable<T>
    internal class Garage : IEnumerable // : IGarage<IEnumerable>
    {
        public event UIwriteDelegate UIwrite;
        public event UIwriteErrorDelegate UIwriteError;
        public event UIwriteWarningDelegate  UIwriteWarning;

        private int VehicleCapacity;
        private Vehicle[] Vehicles;
        private List<string> RegNos = new List<string>();

        public Garage(int vehicleCapacity)
        {
            VehicleCapacity = vehicleCapacity;
            Vehicles = new Vehicle[vehicleCapacity];

        }

 

        public IEnumerator GetEnumerator()
        {
            foreach (Vehicle vehicle in Vehicles)
            {
                yield return vehicle;
            }
        }

        public bool Add(Vehicle vehicle)
        {
            try
            {
                if (IsVehicleAllowedToBeAddedToTheGarage(vehicle))
                {
                    for (int i = 0; i < Vehicles.Length; i++)
                    {
                        if (Vehicles[i] == null)
                        {
                            Vehicles[i] = vehicle;
                            RegNos.Add(vehicle.RegNo);

                            UIwrite($"Added {vehicle} to the GaraGe");

                            return true;
                        }
                    }
                }
            }
            catch (GarageException e)
            {
                UIwriteError(e.Message);
            }

            return false;
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

                UIwriteWarning($"Removed {vehicleInfo} from the Garage. The Garage now has {VehicleCapacity} vehicles left.");
            }
            else
            {
                UIwriteError($"{vehicleInfo} to be removed was not found in the Garage.");
            }

            return true;
        }

        public void PrintGarage()
        {
            UIwrite(" ");
            UIwrite("Garage Content");
            UIwrite("==============");

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle != null)
                {
                    UIwrite(vehicle.ToString());
                }
            }

            UIwrite(" ");
            UIwrite("Press any key to contine...");
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
