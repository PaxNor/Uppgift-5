using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_5.Interfaces;
using Uppgift_5.Vehicles;

/*
 * Representerar ett garage av Vehicles
 */

namespace Uppgift_5
{
    internal class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
    {
        private T[] parkingSpot;
        private readonly uint capacity;
        private uint occupancy;

        // returns index of vehicle with the requested license plate nr.
        // the function returns -1 if the vehicle is not found in garage.
        private int FindParkingSpot(string licensePlateNr) {
            for (int i = 0; i < capacity; i++) {
                if (parkingSpot[i] != null) {
                    if (parkingSpot[i].LicensePlateNr == licensePlateNr) {
                        return i;
                    }
                }
            }
            return -1;
        }

        public Garage(uint capacity) {
            this.parkingSpot = new T[capacity];
            this.occupancy = 0;
            this.capacity = capacity;
        }

        public IEnumerator<T> GetEnumerator() {
            foreach (T v in this.parkingSpot) {
                if (v != null) yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Adds vehicle to garage. Returns true if successful or null if garage is full
        public bool Add(T vehicle) {
            if (occupancy == capacity) return false;

            // find first empty spot
            for (int i = 0; i < capacity; i++) {
                if (parkingSpot[i] == null) {
                    parkingSpot[i] = vehicle;
                    break;
                }
            }
            occupancy++;
            return true;
        }

        // returns vehicle in garage or null if not found
        public Vehicle? FindVehicle(string licensePlateNr) {
            int spot = FindParkingSpot(licensePlateNr);
            return spot == -1 ? null : parkingSpot[spot];

            //return parkingSpot.FirstOrDefault(v => v.LicensePlateNr == licensePlateNr);
        }

        // removes vehicle from garage and returns it or null if not found
        public Vehicle? RemoveVehicle(string licensePlateNr) {
            Vehicle removed;
            int spot = FindParkingSpot(licensePlateNr);
            if (spot == -1) return null;
            removed = parkingSpot[spot];
            parkingSpot.SetValue(null, spot); // can not set directly without warning?!
            occupancy--;
            return removed;
        }

        public bool RemoveVehicle2(string licensePlateNr) {
            for (var i = 0; i < parkingSpot.Length; i++) {
                if (parkingSpot[i].LicensePlateNr == licensePlateNr) {
                    parkingSpot[i] = null;
                    occupancy--;
                    return true;
                }
            }
            return false;
        }

        public uint FreeSpace() {
            return capacity - occupancy;
        }
    }
}
