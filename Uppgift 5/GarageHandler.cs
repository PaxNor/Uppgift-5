using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class GarageHandler
    {
        // removes white space and convert to upper case
        private string CompactUserString(string userString) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in userString) {
                if (char.IsWhiteSpace(c) == false) {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToUpper();
        }

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

        public bool FindVehicle(Garage<Vehicle> garage, string plateNr) {
            string plateFormat = CompactUserString(plateNr);
            var vehicle = garage.FindVehicle(plateFormat);
            return vehicle == null ? false : true;
        }
    }
}
