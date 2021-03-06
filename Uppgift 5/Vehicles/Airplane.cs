namespace Uppgift_5.Vehicles
{
    public class Airplane : Vehicle
    {
        public uint Wingspan { get; }

        public Airplane(string licensePlateNr, uint wheelCount, string color, string brand, uint wingspan)
            : base(licensePlateNr, wheelCount, color, brand) {
            Wingspan = wingspan;
            Type = VehicleType.Airplane;
        }

        public override string ToString() {
            return base.ToString() + $"Type: {Type.ToString(),10}, Wingspan: {Wingspan,3}";
        }

    }
}
