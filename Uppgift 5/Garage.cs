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
        private readonly int capacity;
        private int occupancy;

        public Garage(int capacity) {
            this.parkingSpot = new Vehicle[capacity];
            this.occupancy = 0;
            this.capacity = capacity;
        }

        public IEnumerator<Vehicle> GetEnumerator() {
            foreach (Vehicle v in this.parkingSpot) {
                yield return v;
            }
        }

        // kanske returnera en bool ifall garaget är fullt?
        public void Add(Vehicle vehicle) {
            if (occupancy == capacity) return;
            parkingSpot[occupancy] = vehicle;
            occupancy++;
        }
    }
}
