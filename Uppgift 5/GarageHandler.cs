using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class GarageHandler
    {
        public Dictionary<VehicleType, int> GetStats(Garage<Vehicle> garage) {
            Dictionary<VehicleType, int> stats = new();
            VehicleType type;
            int count = 0;

            foreach (var vehicle in garage) {
                type  = vehicle.Type;

                if (stats.ContainsKey(type)) {
                    count = stats[type];
                }

                count++;
                stats[type] = count;
            }

            return stats;
        }
    }
}
