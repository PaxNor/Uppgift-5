using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Boat : Vehicle
    {
        public int Length { get; set; }

        public Boat(string licensePlateNr, int wheelCount, string color, string brand, int length)
            : base(licensePlateNr, wheelCount, color, brand) {
            Length = length;
        }

        public override string ToString() {
            return base.ToString() + $"Length: {Length}";
        }
    }
}
