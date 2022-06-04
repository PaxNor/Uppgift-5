
using Uppgift_5;

Car car1 = new("ABC123", 4, "Green", "Ford", Car.SubType.sedan);
Car car2 = new("EFG123", 4, "Blue", "Volvo", Car.SubType.SUV);
Car car3 = new("HIJ123", 4, "White", "Peugot", Car.SubType.coupe);
Car car4 = new("KLM123", 4, "Silver", "Fiat", Car.SubType.pickup);

Motorcycle motorcycle1 = new("KLM123", 2, "Red", "Ducati", 300, Motorcycle.SubType.sport);
Motorcycle motorcycle2 = new("KLM123", 2, "Yellow", "Yamaha", 180, Motorcycle.SubType.offroad);

Airplane airplane = new("ESA777", 3, "White", "Boing", 23);

Bus bus1 = new("UUU333", 6, "White", "Scania", 80, 10000);
Bus bus2 = new("MKS876", 4, "Gray", "Mercedes", 16, 2000);

Console.WriteLine(car2);

Garage<Vehicle> garage = new(10);

garage.Add(car1);
garage.Add(car2);
garage.Add(car3);
garage.Add(car4);
garage.Add(motorcycle1);
garage.Add(motorcycle2);
garage.Add(airplane);
garage.Add(bus1);
garage.Add(bus2);

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
Manager ui = new();
ui.Start(garage);


// test // alternative constructor new(10, "Garage A");
Garage<Vehicle> garage2 = new(10) {
    new Car("ABC123", 4, "Green", "Ford", Car.SubType.sedan),
    new Car("ABC123", 4, "Green", "Fiat", Car.SubType.sedan),
    new Car("ABC123", 4, "Green", "Volvo", Car.SubType.sedan),
    new Car("ABC123", 4, "Green", "Saab", Car.SubType.sedan)
};

// Skapa en DemoGarageGenerator klass
