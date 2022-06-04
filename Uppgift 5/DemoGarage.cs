using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Skapar ett garage fullt med fordon i demo syfte
 */

namespace Uppgift_5
{   
    internal static class DemoGarage
    {
        public static Garage<Vehicle> Generate() {
            return new Garage<Vehicle>(30) {

                new Car("ABC123", 4, "green", "Ford", Car.SubType.sedan),
                new Car("QVC878", 4, "blue", "Fiat", Car.SubType.SUV),
                new Car("JIF888", 4, "silver", "Volvo", Car.SubType.coupe),
                new Car("DIU932", 4, "white", "Saab", Car.SubType.coupe),
                new Car("HUY193", 4, "green", "Ford", Car.SubType.coupe),
                new Car("UYD921", 4, "white", "Saab", Car.SubType.sedan),
                new Car("UHD349", 4, "silver", "BMW", Car.SubType.SUV),
                new Car("ISD922", 4, "silver", "Volvo", Car.SubType.sedan),
                new Car("ABB123", 4, "green", "Ford", Car.SubType.sedan),
                new Car("EFG323", 4, "blue", "Volvo", Car.SubType.SUV),
                new Car("HIJ993", 4, "white", "Peugot", Car.SubType.coupe),
                new Car("KLP121", 3, "silver", "Fiat", Car.SubType.pickup),

                new Motorcycle("KLM325", 2, "red", "Ducati", 300, Motorcycle.SubType.sport),
                new Motorcycle("PLO223", 2, "yellow", "Yamaha", 180, Motorcycle.SubType.offroad),
                new Motorcycle("POP111", 3, "black", "Yamaha", 120, Motorcycle.SubType.offroad),

                new Airplane("ESA777", 3, "white", "Boing", 23),
                new Airplane("GGU911", 3, "white", "Boing", 16),
                new Airplane("SPR822", 3, "silver", "Airbus", 32),

                new Bus("UUU333", 6, "white", "Scania", 80, 10000),
                new Bus("MKS876", 4, "gray", "Mercedes", 16, 2000),

                new Boat("MGI776", 0, "white", "Contender", 32),
                new Boat("LLK911", 0, "white", "Angler", 16)
            };
        }
    }
}
