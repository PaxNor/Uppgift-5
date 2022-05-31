
using Uppgift_5;

Car car = new("ABC 123", 4, "Green", "Ford", Car.Type.sedan);
Car car2 = new("ABC 123", 4, "Green", "Ford", Car.Type.sedan);
Car car3 = new("ABC 123", 4, "Green", "Ford", Car.Type.sedan);
Car car4 = new("ABC 123", 4, "Green", "Ford", Car.Type.sedan);
Console.WriteLine(car);

Garage<Vehicle> garage = new(100);
