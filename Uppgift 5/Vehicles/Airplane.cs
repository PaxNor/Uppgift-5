using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5.Vehicles
{
    internal class Airplane : Vehicle
    {
        public uint Wingspan { get; }

        public Airplane(string licensePlateNr, uint wheelCount, string color, string brand, uint wingspan)
            : base(licensePlateNr, wheelCount, color, brand) {
            Wingspan = wingspan;
            Type = VehicleType.Airplane;
        }

        public override string ToString() {
            return base.ToString() + $"Wingspan: {Wingspan,3}, Type: {Type.ToString(),10}";
        }

    }
}
