using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Bus : Vehicle
    {
        public uint SeatCount { get; set; }
        public uint Weight { get; set; }

        public Bus(string licensePlateNr, uint wheelCount, string color, string brand, uint seatCount, uint weight)
            : base(licensePlateNr, wheelCount, color, brand) {
            SeatCount = seatCount;
            Weight = weight;
            base.Type = VehicleType.Bus;
        }

        public override string ToString() {
            return base.ToString() + $"Seats: {SeatCount, 3}, Weight: {Weight, 4}, Type: {Type.ToString(), 10}";
        }
    }
}
