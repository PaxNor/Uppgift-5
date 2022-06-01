using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class GarageHandler<T> where T : Vehicle
    {
        private Garage<T> garage;

        public GarageHandler(Garage<T> garage) {
            this.garage = garage;
        }

        public List<string> GetStats() {
            Dictionary<VehicleType, int> stats = new();
            VehicleType type;
            int count;
            return null;
            //foreach (var vehicle in garage) {
            //    type = vehicle.
            //}
        }
    }
}
