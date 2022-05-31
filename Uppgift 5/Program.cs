
using Uppgift_5;

Car car1 = new("ABC 123", 4, "Green", "Ford", Car.Type.sedan);
Car car2 = new("EFG 123", 4, "Blue", "Volvo", Car.Type.SUV);
Car car3 = new("HIJ 123", 4, "White", "Peugot", Car.Type.coupe);
Car car4 = new("KLM 123", 4, "Silver", "Fiat", Car.Type.pickup);

Console.WriteLine(car2);

Garage<Vehicle> garage = new(10);

garage.Add(car1);
garage.Add(car2);
garage.Add(car3);
garage.Add(car4);

foreach(Vehicle vehicle in garage) {
    //if (vehicle == null) break;
    Console.WriteLine(vehicle);
}

// find car in garage
Vehicle? car = garage.FindVehicle("HIJ 123");
Console.WriteLine(car);

// remove car
car = garage.FindVehicle("uuu 888");
if(car == null) Console.WriteLine("Not found");
car = garage.RemoveVehicle("uuu 888");
if (car == null) Console.WriteLine("Not found");
car = garage.RemoveVehicle("HIJ 123");

// check that is removed
foreach(Vehicle spot in garage) {
    Console.WriteLine(spot);
}
