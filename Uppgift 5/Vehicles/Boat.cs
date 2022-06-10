namespace Uppgift_5.Vehicles
{
    public class Boat : Vehicle
    {
        public uint Length { get; }

        public Boat(string licensePlateNr, uint wheelCount, string color, string brand, uint length)
            : base(licensePlateNr, wheelCount, color, brand) {
            Length = length;
            Type = VehicleType.Boat;
        }

        public override string ToString() {
            return base.ToString() + $"Type: {Type.ToString(),10}, Length: {Length}";
        }
    }
}
