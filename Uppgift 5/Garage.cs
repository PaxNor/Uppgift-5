using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Garage<T> where T : Vehicle
    {
        private Vehicle[] parkingSpot;

        public Garage(int capacity) {
            this.parkingSpot = new Vehicle[capacity];
        }

        public IEnumerator<Vehicle> GetEnumerator() {
            foreach (Vehicle v in this.parkingSpot) {
                yield return v;
            }
        }
    }
}
