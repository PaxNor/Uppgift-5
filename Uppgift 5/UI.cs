using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class UI
    {
        private bool isRunning;
        private string choice;
        private QueryParser parser;
        private GarageHandler garageHandler;
        private Dictionary<VehicleType, int> stats;

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

        private const string prompt = "> ";

        private void CommandPrompt() {
            string input;

            while(true) {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (input == "exit") break;
                parser.Parse(input);
            }
        }

        public UI() {
            parser = new QueryParser();
            garageHandler = new GarageHandler();
        }

        // experimental
        public void Start(Garage<Vehicle> garage) {
            isRunning = true;

            while(isRunning) {
                Console.WriteLine(mainMenu);
                choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        Console.WriteLine("Park vehicle");
                        break;

                    case "2":
                        // done
                        stats = garageHandler.GetStats(garage);
                        foreach (var stat in stats) {
                            Console.WriteLine("{0,-10} {1,2}", stat.Key.ToString(), stat.Value);
                        }
                        break;

                    case "3":
                        // done
                        Console.Write("Enter license plate number: ");
                        string plate = Console.ReadLine();
                        bool found = garageHandler.FindVehicle(garage, plate);
                        if(found) Console.WriteLine($"Vehicle {plate} is in garage");
                        else Console.WriteLine($"Vehicle with plate nr: {plate} not found.");

                        break;
                        
                    case "4":
                        // done
                        Console.Write("Enter license plate number: ");
                        plate = Console.ReadLine();
                        var vehicle = garageHandler.RemoveVehicle(garage, plate);
                        if(vehicle != null) Console.WriteLine($"Vehicle {plate} removed from garage");
                        else Console.WriteLine($"Vehicle with plate nr: {plate} not found.");
                        break;

                    case "5":
                        // done
                        foreach(Vehicle v in garage) {
                            Console.WriteLine(v);
                        }
                        break;

                    case "6":
                        Console.WriteLine(subMenu);
                        CommandPrompt();
                        break;

                    case "7":
                        // done
                        Console.WriteLine($"Available parking spots: {garage.FreeSpace()}");
                        break;

                    case "8":
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        break;
                }

                Console.Write("Hit any key to continue.. ");
                Console.ReadKey();
                Console.Clear();
            }
        }


    }
}
