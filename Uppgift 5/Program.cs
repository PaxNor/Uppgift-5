
using Uppgift_5;
using Uppgift_5.Auxilary;
using Uppgift_5.Vehicles;

/*
 * Konfigurerar och startar upp applikationen
 */

// create demo garage
Garage<Vehicle> garage = DemoGarage.Generate();

// start app
Manager manager = new();
manager.Start(garage);
