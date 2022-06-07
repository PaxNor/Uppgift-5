using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_5.Auxilary;
using Uppgift_5.Interfaces;
using Uppgift_5.Vehicles;

/*
 * Hanterar gränssnitt, skriver ut och tar emot data från terminalen
 */

namespace Uppgift_5
{
    internal class UI : IUI
    {
        private const string mainMenu =
            "1. Park vehicle\n" +
            "2. Show stats\n" +
            "3. Find vehicle\n" +
            "4. Remove vehicle\n" +
            "5. List all vehicles\n" +
            "6. Search by property\n" +
            "7. Show available parking spots\n" +
            "8. Create new garage\n" +
            "9. Quit";

        private const string subMenu =
           "Enter query to list vehicles based on the given properties.\n" +
           "The syntax is key / value pairs separated with commas.\n" +
           "Valid properties are: plate, wheels, color, type and brand\n" +
           "Type \'exit\' to exit to main menu.\n\n" +
           "Example: color black, wheels 3, brand Volvo";

        private void CommandPrompt(IGarageHandler handler) {

            List<Vehicle>? result = null;
            const string error = "Valid properties are: plate, wheels, color, type and brand";
            const string prompt = "> ";
            string input;

            while (true) {
                input = IOUtil.runUserDialog(prompt);
                if (input == "exit") break;

                var queries = IOUtil.ParseQuery(input);
                if (queries == null) Console.WriteLine(error);
                else if (queries[0].Length == 0) { } // ignore empty lines
                else {
                    result = handler.SearchByProperty(queries);
                    if (result == null) Console.WriteLine(error);
                    else if (result.Count == 0) Console.WriteLine("No match");
                    else result.ForEach(p => Console.WriteLine(p));
                }
            }
        }

        // Adds dependency on Vehicle, but the alternative is to add it to the handler eventhough
        // it mostly consists of user io, and then the handler has a dependency on vehicle.
        private static Vehicle CreateVehicle() {

            string type = IOUtil.runUserDialog("Enter vehicle type: ", "car", "bus", "motorcycle", "boat", "airplane");
            string licensePlate = IOUtil.runUserDialog("Enter license plate: ");
            licensePlate = IOUtil.CompactUserString(licensePlate);
            string color = IOUtil.runUserDialog("Enter color: ");
            string brand = IOUtil.runUserDialog("Enter brand: ");
            brand = IOUtil.NameCase(brand);
            uint wheelCount = IOUtil.runUserDialogNumeric("Enter wheel count: ");
            string subType;

            switch (type.ToLower()) {

                case "car":
                    subType = IOUtil.runUserDialog("Enter model (sedan, coupe, pickup suv): ", "sedan", "coupe", "convertible", "pickup", "suv");
                    Car.SubType carType = (Car.SubType)Enum.Parse(typeof(Car.SubType), subType, true);
                    return new Car(licensePlate, wheelCount, color, brand, carType);

                case "bus":
                    uint seatCount = IOUtil.runUserDialogNumeric("Enter seat count: ");
                    uint weight = IOUtil.runUserDialogNumeric("Enter weight: ");
                    return new Bus(licensePlate, wheelCount, color, brand, seatCount, weight);

                case "motorcycle":
                    subType = IOUtil.runUserDialog("Enter model (offroad, sport, classic): ", "offroad", "sport", "classic");
                    uint speed = IOUtil.runUserDialogNumeric("Enter top speed: ");
                    Motorcycle.SubType motorcycleType = (Motorcycle.SubType)Enum.Parse(typeof(Motorcycle.SubType), subType, true);
                    return new Motorcycle(licensePlate, wheelCount, color, brand, speed, motorcycleType);

                case "boat":
                    uint length = IOUtil.runUserDialogNumeric("Enter length: ");
                    return new Boat(licensePlate, wheelCount, color, brand, length);

                case "airplane":
                    uint wingspan = IOUtil.runUserDialogNumeric("Enter wingspan: ");
                    return new Airplane(licensePlate, wheelCount, color, brand, wingspan);

                default:
                    // this can't happen
                    throw new Exception("Attempt at creating a vehicle type that does not exist.");
            }
        }

        // -- Menu items --

        public string MenuPicker() {
            string? result;
            Console.WriteLine(mainMenu);
            do {
                result = Console.ReadLine();
            } while (result == null);
            return result;
        }

        public void ParkVehicle(IGarageHandler handler) {
            Vehicle vehicle = CreateVehicle();
            if (handler.AddVehicle(vehicle) == false) {
                Console.WriteLine("Garage is full");
            }
            else {
                Console.WriteLine("Vehicle parked");
            }
        }

        public void ShowStats(IGarageHandler handler) {
            Dictionary<VehicleType, int> stats = handler.GetStats();
            foreach (var stat in stats) {
                Console.WriteLine("{0,-10} {1,2}", stat.Key.ToString(), stat.Value);
            }
        }

        public void FindVehicle(IGarageHandler handler) {
            string plate = IOUtil.runUserDialog("Enter license plate number: ");
            bool found = handler.FindVehicle(plate);
            if (found) Console.WriteLine($"Vehicle {plate} is in garage");
            else Console.WriteLine($"Vehicle with plate nr: {plate} not found.");
        }

        public void RemoveVehicle(IGarageHandler handler) {
            string plate = IOUtil.runUserDialog("Enter license plate number: ");
            Vehicle? vehicle = handler.RemoveVehicle(plate);
            if (vehicle != null) Console.WriteLine($"Vehicle {plate} removed from garage");
            else Console.WriteLine($"Vehicle with plate nr: {plate} not found.");
        }

        public void SearchByProperty(IGarageHandler handler) {
            Console.WriteLine(subMenu);
            CommandPrompt(handler);
        }

        public void ShowFreeSpace(IGarageHandler handler) {
            Console.WriteLine($"Available parking spots: {handler.FreeSpace()}");
        }

        public void CreateNewGarage(IGarageHandler handler) {
            uint capacity = IOUtil.runUserDialogNumeric("Enter capacity of new garage: ");
            handler.CreateNewGarage(capacity);
            Console.WriteLine("New garage added");
        }

        // wrappers
        public void PrintObject(object? obj) {
            Console.WriteLine(obj);
        }

        public void ReportError(string message) {
            Console.WriteLine(message);
        }
    }
}
