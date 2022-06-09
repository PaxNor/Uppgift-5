using Uppgift_5.Auxilary;
using Uppgift_5.Interfaces;
using Uppgift_5.Vehicles;

/*
 * Hanterar ett garage och implementerar funktionalitet till applikationen
 */

namespace Uppgift_5
{
    internal class GarageHandler : IGarageHandler
    {
        private IGarage<Vehicle>? garage;

        // not declared in interface, not used
        public Dictionary<VehicleType, int> GetStatsDict() {
            Dictionary<VehicleType, int> stats = new();
            VehicleType type;

            foreach (var vehicle in garage) {
                type = vehicle.Type;

                if (stats.ContainsKey(type))
                    stats[type]++;
                else
                    stats[type] = 1;
            }

            return stats;
        }

        public List<string> GetStats() {
            int sum = 0;
            List<string> stats = new();

            var groupByVehicleType = from vehicle in garage
                                     group vehicle by vehicle.Type;

            foreach (var vehicleGroup in groupByVehicleType) {
                foreach (var vehicle in vehicleGroup) {
                    sum++;
                }
                string result = string.Format("{0,-10} {1,2}", vehicleGroup.Key.ToString(), sum);
                stats.Add(result);
                sum = 0;
            }
            return stats;
        }

        public void InitWithGarage(IGarage<Vehicle> garage) {
            this.garage = garage;
        }

        public bool FindVehicle(string plateNr) {
            string plateFormat = IOUtil.CompactUserString(plateNr);
            var vehicle = garage.FindVehicle(plateFormat);
            return vehicle == null ? false : true;
        }

        public Vehicle? RemoveVehicle(string plateNr) {
            string plateFormat = IOUtil.CompactUserString(plateNr);
            return garage.RemoveVehicle(plateFormat);
        }

        public bool AddVehicle(Vehicle vehicle) => garage.Add(vehicle);

        public void CreateNewGarage(uint capacity) {
                    garage = new Garage<Vehicle>(capacity);
        }

        public List<Vehicle>? SearchByProperty(List<string[]> queries) {

            var q = garage.Select(p => p);

            foreach (var query in queries) {
                switch (query[0]) {

                    case "plate":
                        q = q.Where(p => p.LicensePlateNr == IOUtil.CompactUserString(query[1]));
                        break;

                    case "color":
                        q = q.Where(p => IOUtil.NoCaseCompare(p.Color, query[1])); 
                        break;

                    case "wheels":
                        q = q.Where(p => p.WheelCount.ToString() == query[1]);
                        break;

                    case "brand":
                        q = q.Where(p => IOUtil.NoCaseCompare(p.Brand, query[1]));
                        break;

                    case "type":
                        q = q.Where(p => IOUtil.NoCaseCompare(p.Type.ToString(), query[1]));    
                        break;

                    default:
                        // maybe throw exception instead?
                        return null;
                }
            }
            return q.ToList();
        }

        public void ListVehicles(IUI ui) {
            foreach (Vehicle v in garage) {
                ui.PrintObject(v);
            }
        }

        public uint FreeSpace() {
            return garage.FreeSpace();
        }

    }
}
