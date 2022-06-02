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

            foreach (var vehicle in garage) {
                type  = vehicle.Type;

                if (stats.ContainsKey(type)) 
                    stats[type]++;
                else 
                    stats[type] = 1;
            }

            return stats;
        }

        public bool FindVehicle(Garage<Vehicle> garage, string plateNr) {
            string plateFormat = CompactUserString(plateNr);
            var vehicle = garage.FindVehicle(plateFormat);
            return vehicle == null ? false : true;
        }

        public Vehicle? RemoveVehicle(Garage<Vehicle> garage, string plateNr) {
            string plateFormat = CompactUserString(plateNr);
            return garage.RemoveVehicle(plateFormat);
        }

        public List<Vehicle>? SearchByProperty(Garage<Vehicle> garage, List<string[]> queries) {

            var q = garage.Select(p => p);

            foreach (var query in queries) {
                switch (query[0]) {

                    case "plate":
                        q = q.Where(p => p.LicensePlateNr == query[1]);
                        break;

                    case "color":
                        q = q.Where(p => p.Color == query[1]);
                        break;

                    case "wheels":
                        q = q.Where(p => p.WheelCount.ToString() == query[1]);
                        break;

                    case "brand":
                        q = q.Where(p => p.Brand == query[1]);
                        break;

                    case "type":
                        q = q.Where(p => p.Type.ToString() == query[1]);
                        break;

                    default:
                        // maybe throw exception instead?
                        return null;
                }
            }
            return q.ToList();
        }
    }
}
