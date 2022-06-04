
using Uppgift_5;

// create demo garage
Garage<Vehicle> garage = DemoGarage.Generate();

// start app
Manager manager = new();
manager.Start(garage);
