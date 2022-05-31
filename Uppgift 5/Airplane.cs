﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Airplane : Vehicle
    {
        public int Wingspan { get; set; }

        public Airplane(string licensePlateNr, int wheelCount, string color, string brand, int wingspan)
            : base(licensePlateNr, wheelCount, color, brand) {
            Wingspan = wingspan;
        }

        public override string ToString() {
            return base.ToString() + $"Wingspan: {Wingspan}";
        }

    }
}
