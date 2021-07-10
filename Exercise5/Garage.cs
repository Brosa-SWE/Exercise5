﻿using System;
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
        public event UIwriteWarningDelegate UIwriteWarning;

        private int _vehicleCapacity;
        public int VehicleCapacity { get { return _vehicleCapacity; } }

        private Vehicle[] Vehicles;

        public Garage(int vehicleCapacity)
        {
            _vehicleCapacity = vehicleCapacity;
            Vehicles = new Vehicle[vehicleCapacity];

        }

        public bool IsEmpty
        {
            
            get
            {

                Console.WriteLine("Count: " + Count);
                Console.ReadKey();

                if (Count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Vehicle vehicle in Vehicles)
            {
                yield return vehicle;
            }
        }

        public int Count { 
            
            get 
            { 
                if(Vehicles == null)
                {
                    return 0;
                }

                if (!Vehicles.Any())
                {
                    return 0;
                }
                return Vehicles.Count(); 
            } 
        }

        public int FreeSpaces { get { return VehicleCapacity - Count; } }

        public bool HasRegNo(string RegNo)
        {
            var Match = Vehicles.FirstOrDefault(vehicle => vehicle?.RegNo == RegNo);

            return Match != null;
        }

        public bool IsFull()
        {
            return VehicleCapacity == Count;
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
