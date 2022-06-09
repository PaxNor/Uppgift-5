using Uppgift_5.Vehicles;

namespace Uppgift_5.Interfaces
{
    internal interface IGarageHandler
    {
        bool AddVehicle(Vehicle vehicle);
        void CreateNewGarage(uint capacity);
        bool FindVehicle(string plateNr);
        uint FreeSpace();
        List<string> GetStats(); 
        void InitWithGarage(IGarage<Vehicle> garage);
        void ListVehicles(IUI ui);
        Vehicle? RemoveVehicle(string plateNr);
        List<Vehicle>? SearchByProperty(List<string[]> queries);
    }
}