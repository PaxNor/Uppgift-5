using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Dictionary<VehicleType, int> GetStats() {
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

        // TODO: either remove type selection or solve it.
        public void CreateNewGarage(VehicleType type, uint capacity) {
            switch (type) {
                case VehicleType.Car:
                    garage = new Garage<Vehicle>(capacity);
                    break;
                case VehicleType.Bus:
                    garage = new Garage<Vehicle>(capacity);
                    break;
                case VehicleType.Motorcycle:
                    garage = new Garage<Vehicle>(capacity);
                    break;
                case VehicleType.Boat:
                    garage = new Garage<Vehicle>(capacity);
                    break;
                case VehicleType.Airplane:
                    garage = new Garage<Vehicle>(capacity);
                    break;
                case VehicleType.Vehicle:
                    garage = new Garage<Vehicle>(capacity);
                    break;
                default:
                    throw new Exception("Unsupported garage type");
            }
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
