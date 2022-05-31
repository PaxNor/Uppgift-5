using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal abstract class Vehicle
    {
        // x. registreringsnummer, färg, antal hjul och andra egenskaper ni kan komma på.
        public string LicensePlateNr { get; set; }
        public int WheelCount { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }

        public Vehicle(string licensePlateNr, int wheelCount, string color, string brand) {
            LicensePlateNr = licensePlateNr;
            WheelCount = wheelCount;
            Color = color;
            Brand = brand;
        }

        public override string ToString() {
            return $"License plate: {LicensePlateNr}" +
                   $"Wheel count: {WheelCount}" +
                   $"Color: {Color}" +
                   $"Brand: {Brand}";
        }
    }
}
