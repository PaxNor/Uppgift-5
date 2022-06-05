namespace Uppgift_5.Interfaces
{
    internal interface IUI
    {
        void FindVehicle(IGarageHandler handler);
        string MenuPicker();
        void ParkVehicle(IGarageHandler handler);
        void PrintObject(object? message);
        void RemoveVehicle(IGarageHandler handler);
        void ReportError(string message);
        void SearchByProperty(IGarageHandler handler);
        void ShowFreeSpace(IGarageHandler handler);
        void ShowStats(IGarageHandler handler);
    }
}