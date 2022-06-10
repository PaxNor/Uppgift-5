namespace Uppgift_5.Vehicles
{
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
