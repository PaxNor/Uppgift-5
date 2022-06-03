using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class GarageHandler
    {
        private Garage<Vehicle>? garaget;

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

        // Add new vehicle to garage. - TODO: fix how this is done, the UI should not hold reference to garage.
        public bool AddVehicle(Garage<Vehicle> garage, Vehicle vehicle) => garage.Add(vehicle);

        // Create a new garage
        public Object? CreateNewGarage(VehicleType type, uint capacity) {
            switch (type) {
                case VehicleType.Car:           return new Garage<Car>(capacity);
                case VehicleType.Bus:           return new Garage<Bus>(capacity);
                case VehicleType.Motorcycle:    return new Garage<Motorcycle>(capacity);
                case VehicleType.Boat:          return new Garage<Boat>(capacity);
                case VehicleType.Airplane:      return new Garage<Airplane>(capacity);
                case VehicleType.Vehicle:       return new Garage<Vehicle>(capacity);
            }
            return null;
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
