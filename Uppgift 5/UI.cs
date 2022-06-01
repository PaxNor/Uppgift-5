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

        private const string mainMenu =
            "1. Park vehicle\n" +
            "2. Find vehicle\n" +
            "3. Remove vehicle\n" +
            "4. List all vehicles\n" +
            "5. Search by property\n" +
            "6. Show available parking spots\n" +
            "7. Quit";

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
        }

        // experimental
        public void Start(Garage<Vehicle> garage) {
            isRunning = true;

            while(isRunning) {
                Console.WriteLine(mainMenu);
                choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        Console.WriteLine("Add."); 
                        // choose type
                        // add to garage
                        break;

                    case "2":
                        Console.WriteLine("Find.");
                        // search on license plate
                        // return car
                        break;

                    case "3":
                        Console.WriteLine("Remove.");
                        // search on license plate
                        // return car
                        break;

                    case "4":
                        // done
                        foreach(Vehicle v in garage) {
                            Console.WriteLine(v);
                        }
                        break;

                    case "5":
                        // search by property
                        Console.WriteLine(subMenu);
                        CommandPrompt();
                        break;

                    case "6":
                        // done
                        Console.WriteLine($"Available parking spots: {garage.FreeSpace()}");
                        break;

                    case "7":
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
