namespace Uppgift_5.Interfaces
{
    internal interface IUI
    {
        void FindVehicle(GarageHandler handler);
        string MenuPicker();
        void ParkVehicle(GarageHandler handler);
        void PrintObject(object? message);
        void RemoveVehicle(GarageHandler handler);
        void ReportError(string message);
        void SearchByProperty(GarageHandler handler);
        void ShowFreeSpace(GarageHandler handler);
        void ShowStats(GarageHandler handler);
    }
}