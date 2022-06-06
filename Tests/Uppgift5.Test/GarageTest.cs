using Xunit;
using Uppgift_5;
using Uppgift_5.Vehicles;

namespace Uppgift5.Test
{
    public class GarageTest
    {
        // Add one method per test, rename to the method to
        // the method in garage that is being tested.
        [Fact]
        public void AddAndFindTest() {
            //-- Arrange
            Garage<Vehicle> garage = new(10);
            //Car car = new("ABC123", 4, "red", "Volvo", Car.SubType sedan);
            Bus bus = new("ABC123", 6, "white", "Scania", 80, 10000);

            //-- Act
            garage.Add(bus);

            //-- Assert
            Assert.NotNull(garage.FindVehicle("ABC123"));
        }
    }
}