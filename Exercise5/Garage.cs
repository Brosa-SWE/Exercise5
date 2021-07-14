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
        // public event UIwriteDelegate UIwrite;
        public event UIwriteErrorDelegate UIwriteError;
        // public event UIwriteWarningDelegate UIwriteWarning;

        private int _vehicleCapacity;
        public int VehicleCapacity { get { return _vehicleCapacity; } }

        private Vehicle[] Vehicles;

        public Garage(int vehicleCapacity)
        {
            _vehicleCapacity = vehicleCapacity;
            Vehicles = new Vehicle[vehicleCapacity];

        }
        public bool HasAtLeastOneVehicleParked { get { return Count > 0; } }

        public bool HasRoom { get { return !IsFull; } }

        public bool IsFull { get { return VehicleCapacity == Count; } }

        public bool IsEmpty { get { return Count == 0; } }

        public int FreeSpaces { get { return VehicleCapacity - Count; } }

        public IEnumerator GetEnumerator()
        {
            foreach (Vehicle vehicle in Vehicles)
            {
                yield return vehicle;
            }
        }

        public int Count
        {

            get
            {
                if (Vehicles == null)
                {
                    return 0;
                }

                return Vehicles.Count(s => s != null);
            }
        }


        public bool ContainsRegNo(string RegNo)
        {
            return GetVehicleByRegNo(RegNo) != null;
        }

        public Vehicle GetVehicleByRegNo(string RegNo)
        {
            Vehicle MatchingVehicle = Vehicles.FirstOrDefault(vehicle => vehicle?.RegNo == RegNo);

            return MatchingVehicle;
        }

        public List<string> GetVehiclesMatchingRegNo(string RegNo)
        {

            var MatchingVehicles = from Vehicle in Vehicles
                                   where Vehicle.RegNo.IndexOf(RegNo, StringComparison.InvariantCultureIgnoreCase) >= 0
                                   select Vehicle;

            List<string> ReturnValues = new List<string>();

            foreach (Vehicle Vehicle in MatchingVehicles)
            {
                ReturnValues.Add(Vehicle.ToString());
            }

            return ReturnValues;
        }

        public List<string> GetUniqueVehicleColors()
        {
            var MatchingValues = from Vehicle in Vehicles select Vehicle.Color;

            var UniqueReturnValues = GetUniqueValuesFromList(MatchingValues);

            return UniqueReturnValues;
        }

        public List<string> GetUniqueVehicleTypes()
        {
            var MatchingValues = from Vehicle in Vehicles select Vehicle.VehicleType;

            var UniqueReturnValues = GetUniqueValuesFromList(MatchingValues);

            return UniqueReturnValues;
        }

        public List<string> GetUniqueVehicleWheels()
        {
            var MatchingValues = from Vehicle in Vehicles select Vehicle.NoOfWheels.ToString();

            var UniqueReturnValues = GetUniqueValuesFromList(MatchingValues);

            return UniqueReturnValues;
        }

        private List<string> GetUniqueValuesFromList(IEnumerable<string> ListToGetUniqueValuesFrom)
        {
            List<string> ReturnValues = new List<string>();

            foreach (string Value in ListToGetUniqueValuesFrom)
            {
                ReturnValues.Add(Value);
            }

            var UniqueReturnValues = new HashSet<string>(ReturnValues);

            return UniqueReturnValues.ToList();
        }

        private IEnumerable<Vehicle> GetVehicleColByProperties(string VehicleType, string RegNo, string Color, string NoOfWheels)
        {

            var MatchingVehicles = from Vehicle in Vehicles
                                   where Vehicle.VehicleType.IndexOf(VehicleType) >= 0
                                   where Vehicle.RegNo.IndexOf(RegNo) >= 0
                                   where Vehicle.Color.IndexOf(Color) >= 0
                                   where Vehicle.NoOfWheels.IndexOf(NoOfWheels) >= 0
                                   select Vehicle;

            return MatchingVehicles;
        }

        public List<string> GetVehiclesByProperties(string VehicleType, string Color, string NoOfWheels)
        {

            var MatchingVehicles = from Vehicle in Vehicles
                                   where Vehicle.VehicleType.IndexOf(VehicleType) >= 0
                                   where Vehicle.Color.IndexOf(Color) >= 0
                                   where Vehicle.NoOfWheels.IndexOf(NoOfWheels) >= 0
                                   select Vehicle;

            List<string> ReturnValues = new List<string>();

            foreach (Vehicle Vehicle in MatchingVehicles)
            {
                ReturnValues.Add(Vehicle.ToString());
            }

            return ReturnValues;
        }



        public bool Add(Vehicle vehicle)
        {
            try
            {
                if (vehicle == null)
                {
                    throw new GarageException(9999, "Vehicle object was null in Add method");
                }
            }
            catch (GarageException e)
            {
                UIwriteError(e.Message);
                return false;
            }

            // Add vehicle to first free spot
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] == null)
                {
                    Vehicles[i] = vehicle;

                    break;

                }
            }

            return true;
        }


        public bool Remove(Vehicle vehicle)
        {

            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] == vehicle)
                {
                    Vehicles = Vehicles.Where((source, index) => index != i).ToArray();
                    return true;
                }
            }

            return false;
        }

        public Dictionary<string, int> VehiclesByType()
        {
            Dictionary<string, int> VehiclesByType = new Dictionary<string, int>();

            foreach (Vehicle Vehicle in Vehicles)
            {
                if (Vehicle != null)
                {
                    if (VehiclesByType.ContainsKey(Vehicle?.VehicleType))
                    {
                        VehiclesByType[Vehicle.VehicleType] += 1;
                    }
                    else
                    {
                        VehiclesByType[Vehicle.VehicleType] = 1;
                    }

                }
            }

            return VehiclesByType;
        }

        public List<string> VehiclesByRegNo()
        {
            List<String> VehiclesByRegNo = new List<string>();

            foreach (Vehicle Vehicle in Vehicles)
            {
                if (Vehicle != null)
                {
                    VehiclesByRegNo.Add(Vehicle.ToString());
                }
            }

            return VehiclesByRegNo;

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
