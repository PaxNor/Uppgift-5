using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Motorcycle : Vehicle
    {
        public enum Type { sport, offroad, classic };
        public int TopSpeed { get; set; }
        private Type type; 

        public Motorcycle(string licensePlateNr, int wheelCount, string color, string brand, int topspeed, Type type)
            : base(licensePlateNr, wheelCount, color, brand) {
            TopSpeed = topspeed;
            this.type = type;
        }

        public override string ToString() {
            return base.ToString() + $"Top speed: {TopSpeed}, Type: {type.ToString()}";
        }
    }
}
