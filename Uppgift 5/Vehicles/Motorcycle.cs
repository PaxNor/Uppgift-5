namespace Uppgift_5.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public enum SubType { sport, offroad, classic };

        public uint TopSpeed { get; }
        private SubType subType;

        public Motorcycle(string licensePlateNr, uint wheelCount, string color, string brand, uint topspeed, SubType subType)
            : base(licensePlateNr, wheelCount, color, brand) {
            TopSpeed = topspeed;
            Type = VehicleType.Motorcycle;
            this.subType = subType;
        }

        public override string ToString() {
            return base.ToString() + $"Type: {Type.ToString(),10}, Subtype: {subType.ToString()}, Speed: {TopSpeed,3}";
        }
    }
}
