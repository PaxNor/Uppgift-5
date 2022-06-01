using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Bus : Vehicle
    {
        public int SeatCount { get; set; }
        public int Weight { get; set; }

        public Bus(string licensePlateNr, uint wheelCount, string color, string brand, int seatCount, int weight)
            : base(licensePlateNr, wheelCount, color, brand) {
            SeatCount = seatCount;
            Weight = weight;
            base.Type = VehicleType.Bus;
        }

        public override string ToString() {
            return base.ToString() + $"Seat count: {SeatCount, 3}, Weight: {Weight, 4}, Type: {Type.ToString(), 10}";
        }
    }
}
