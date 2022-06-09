using Xunit;
using Uppgift_5;
using Uppgift_5.Vehicles;

namespace Uppgift5.Test
{
    public class GarageTest
    {
        [Fact]
        public void AddTest() {
            //-- Arrange
            Garage<Vehicle> garage = new(10);
            Bus bus = new("ABC123", 6, "white", "Scania", 80, 10000);

            //-- Act
            garage.Add(bus);

            //-- Assert
            Assert.Contains(bus, garage);
        }

        [Fact]
        public void FreeSpaceTest() {
            //-- Arrange
            Garage<Vehicle> garage = new(10);
            Boat boat = new("ABC123", 0, "white", "BoatInc", 24);

            //-- Act
            garage.Add(boat);

            //-- Assert
            Assert.Equal("9", garage.FreeSpace().ToString());
        }

        [Fact]
        public void RemoveVehicleTest() {
            //-- Arrange
            Garage<Vehicle> garage = new(10);
            Bus bus = new("ABC123", 4, "silver", "Mercedes", 12, 2000);
            Bus? removedBus;

            //-- Act
            garage.Add(bus);
            removedBus = (Bus?)garage.RemoveVehicle("ABC123");

            //-- Assert
            Assert.True(removedBus != null);
            Assert.Equal(bus, removedBus);
            Assert.Equal("10", garage.FreeSpace().ToString());
        }

        [Fact]
        public void FindVehicleTest() {
            //-- Arrange
            Garage<Vehicle> garage = new(10);
            Bus bus = new("ABC123", 4, "gray", "Ford", 10, 2000);
            Bus? foundVehicle;

            //-- Act
            garage.Add(bus);
            foundVehicle = (Bus?)garage.FindVehicle("ABC123");

            //-- Assert
            Assert.Equal(bus, foundVehicle);
        }
    }
}