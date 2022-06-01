
using Uppgift_5;

Car car1 = new("ABC123", 4, "Green", "Ford", Car.SubType.sedan);
Car car2 = new("EFG123", 4, "Blue", "Volvo", Car.SubType.SUV);
Car car3 = new("HIJ123", 4, "White", "Peugot", Car.SubType.coupe);
Car car4 = new("KLM123", 4, "Silver", "Fiat", Car.SubType.pickup);

Console.WriteLine(car2);

Garage<Vehicle> garage = new(10);

garage.Add(car1);
garage.Add(car2);
garage.Add(car3);
garage.Add(car4);

foreach(Vehicle vehicle in garage) {
    Console.WriteLine(vehicle);
}

// find car in garage
Vehicle? car = garage.FindVehicle("HIJ123");
Console.WriteLine(car);

// report free space
Console.WriteLine($"Free spots: {garage.FreeSpace()}");

// remove car
car = garage.FindVehicle("uuu 888");
if(car == null) Console.WriteLine("Not found");
car = garage.RemoveVehicle("uuu 888");
if (car == null) Console.WriteLine("Not found");
car = garage.RemoveVehicle("HIJ123");

// report free space
Console.WriteLine($"Free spots: {garage.FreeSpace()}");


// check that is removed
foreach (Vehicle spot in garage) {
    Console.WriteLine(spot);
}

// 1st test of UI
UI ui = new();
ui.Start(garage);

