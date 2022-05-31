﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Car : Vehicle {

        public enum Type { sedan, convertible, pickup };

        private Type type;

        public Car(string licensePlateNr, int wheelCount, string color, string brand, Type type) 
            : base(licensePlateNr, wheelCount, color, brand)
        {
            this.type = type;
        }

        public override string ToString() {
            return base.ToString() + $"Type: {type.ToString()}";
        }
    }
}
