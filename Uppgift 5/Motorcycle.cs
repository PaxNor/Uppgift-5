using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Motorcycle : Vehicle
    {
        public enum SubType { sport, offroad, classic };

        public int TopSpeed { get; }
        private SubType subType; 

        public Motorcycle(string licensePlateNr, uint wheelCount, string color, string brand, int topspeed, SubType subType)
            : base(licensePlateNr, wheelCount, color, brand) 
        {
            TopSpeed = topspeed;
            base.Type = VehicleType.Motorcycle;
            this.subType = subType;
        }

        public override string ToString() {
            return base.ToString() + $"Speed: {TopSpeed, 3}, Type: {Type.ToString(), 10}, Subtype: {subType.ToString()}";
        }
    }
}
