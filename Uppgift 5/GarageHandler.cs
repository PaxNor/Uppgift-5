using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class GarageHandler
    {
        private Garage<Vehicle>? garage;

        public Dictionary<VehicleType, int> GetStats() {
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

        // temporary hack!
        public void InitWithGarage(Garage<Vehicle> garage) {
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

        public List<Vehicle>? SearchByProperty(List<string[]> queries) {

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

        public void ListVehicles(UI ui) { // TODO: change NUI ref to UI
            foreach (Vehicle v in garage) {
                ui.PrintObject(v);
            }
        }

        public uint FreeSpace() {
            return garage.FreeSpace();
        }
    }
}
