using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Garage<T> : IEnumerable<T>
    {

        private Vehicle[] Vehicles;

        public Garage(int noOfVehicles)
        {
            Vehicles = new Vehicle[noOfVehicles];

        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
