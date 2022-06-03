using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class NUI
    {
        private const string mainMenu =
            "1. Park vehicle\n" +
            "2. Show stats\n" +
            "3. Find vehicle\n" +
            "4. Remove vehicle\n" +
            "5. List all vehicles\n" +
            "6. Search by property\n" +
            "7. Show available parking spots\n" +
            "8. Quit";

        private const string subMenu =
           "Enter query to list vehicles based on the given properties.\n" +
           "The syntax is key / value pairs separated with commas.\n" +
           "Valid properties are: plate, wheels, color, type and brand\n" +
           "Type \'exit\' to exit to main menu.\n\n" +
           "Example: color black, wheels 3, brand Volvo";

        private void CommandPrompt(GarageHandler handler) {

            List<Vehicle>? result = null;
            const string error = "Valid properties are: plate, wheels, color, type and brand";
            const string prompt = "> ";
            string input;

            while (true) {
                input = IOUtil.runUserDialog(prompt);
                if (input == "exit") break;

                var queries = IOUtil.ParseQuery(input);
                if (queries == null) Console.WriteLine(error);
                else if (queries[0].Length == 0) { } // ignores empty lines
                else {
                    result = handler.SearchByProperty(queries);
                    if (result == null) Console.WriteLine(error);
                    else if (result.Count == 0) Console.WriteLine("No match");
                    else result.ForEach(p => Console.WriteLine(p));
                }
            }
        }


        // Menu items

        public string? MainMenuPicker() {
            string? result;
            Console.WriteLine(mainMenu);
            do {
                result = Console.ReadLine();
            } while (result == null);
            return result;
        }

        // UI.ParkVehicle(garageHandler);  TODO

        public void ShowStats(GarageHandler handler) {
            Dictionary<VehicleType, int> stats = handler.GetStats();
            foreach (var stat in stats) {
                Console.WriteLine("{0,-10} {1,2}", stat.Key.ToString(), stat.Value);
            }
        }

        public void FindVehicle(GarageHandler handler) {
            string plate = IOUtil.runUserDialog("Enter license plate number: ");
            bool found = handler.FindVehicle(plate);
            if (found) Console.WriteLine($"Vehicle {plate} is in garage");
            else Console.WriteLine($"Vehicle with plate nr: {plate} not found.");
        }

        public void RemoveVehicle(GarageHandler handler) {
            string plate = IOUtil.runUserDialog("Enter license plate number: ");
            Vehicle vehicle = handler.RemoveVehicle(plate);
            if (vehicle != null) Console.WriteLine($"Vehicle {plate} removed from garage");
            else Console.WriteLine($"Vehicle with plate nr: {plate} not found.");
        }

        public void SearchByProperty(GarageHandler handler) { 
            Console.WriteLine(subMenu);
            CommandPrompt(handler);
        }

        public void ShowFreeSpace(GarageHandler handler) {
            Console.WriteLine($"Available parking spots: {handler.FreeSpace()}");
        }

        // wrapper
        public void PrintObject(object? message) {
            Console.WriteLine(message);
        }
    }
}
