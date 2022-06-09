/*
 * This enum is intended to be used to tag vehicles with their
 * type. This will enable searches by type in the garage. These
 * fields does not exist yet in the vehicle subclasses.
 */

namespace Uppgift_5.Vehicles
{
    [Serializable]
    public enum VehicleType
    {
        Car,
        Motorcycle,
        Bus,
        Airplane,
        Boat,
        Vehicle
    }
}

