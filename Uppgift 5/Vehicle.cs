using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal abstract class Vehicle
    { 
        public string LicensePlateNr { get; }
        public uint WheelCount { get; }
        public string Color { get; }
        public string Brand { get; }
        public VehicleType Type { get; protected set; }

        public Vehicle(string licensePlateNr, uint wheelCount, string color, string brand) {
            LicensePlateNr = licensePlateNr;
            WheelCount = wheelCount;
            Color = color;
            Brand = brand;
        }

        public override string ToString() {
            return $"Plate Nr: {LicensePlateNr, 7}, " +
                   $"Wheels: {WheelCount, 2}, " +
                   $"Color: {Color, 7}, " +
                   $"Brand: {Brand, 9}, ";
        }
    }
}
