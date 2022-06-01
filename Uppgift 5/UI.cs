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
            "6. Show free space\n" +
            "7. Quit";

        private const string subMenu =
            "Enter query to list vehicles based on the given properties.\n" +
            "The syntax is key / value pairs separated with commas.\n" +
            "Valid properties are: plate, wheels, color and brand\n" +
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
        public void Start() {
            isRunning = true;

            while(isRunning) {
                Console.WriteLine(mainMenu);
                choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        Console.WriteLine("Add.");
                        break;

                    case "2":
                        Console.WriteLine("Find.");
                        break;

                    case "3":
                        Console.WriteLine("Remove.");
                        break;

                    case "4":
                        Console.WriteLine("List.");
                        break;

                    case "5":
                        Console.WriteLine(subMenu);
                        CommandPrompt();
                        break;

                    case "6":
                        Console.WriteLine("Show free space.");
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
