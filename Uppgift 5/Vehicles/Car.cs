using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5.Vehicles
{
    [Serializable]
    public class Car : Vehicle
    {

        public enum SubType { coupe, sedan, convertible, pickup, SUV };
        private SubType subType;

        public Car(string licensePlateNr, uint wheelCount, string color, string brand, SubType subType)
            : base(licensePlateNr, wheelCount, color, brand) {
            Type = VehicleType.Car;
            this.subType = subType;
        }

        public override string ToString() {
            return base.ToString() + $"Type: {Type.ToString(),10}, SubType: {subType.ToString()}";
        }
    }
}
