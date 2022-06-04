namespace Uppgift_5.Interfaces
{
    internal interface IGarage<T> where T : Vehicle
    {
        bool Add(T vehicle);
        Vehicle? FindVehicle(string licensePlateNr);
        uint FreeSpace();
        IEnumerator<T> GetEnumerator();
        Vehicle? RemoveVehicle(string licensePlateNr);
        bool RemoveVehicle2(string licensePlateNr);
    }
}