using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class QueryParser
    {
        private const string error = "Unknown property, available: plate, color, wheels, type and brand.";

        // syntax: property1 value1, property2 value2, property3 value3
        public void Parse(string input) {

            StringSplitOptions splitOptions =
                StringSplitOptions.TrimEntries |
                StringSplitOptions.RemoveEmptyEntries;

            string[] queries = input.Split(',');

            foreach (string query in queries) {
                string[] pair = query.Split(' ', splitOptions);

                if (pair.Length > 2) {
                    Console.Write(error);
                    break;
                }

                // properties: plate, color, wheels, brand, type
                switch (pair[0]) {

                    case "plate":
                        Console.Write($"Plate: {pair[1]} ");
                        break;

                    case "color":
                        Console.Write($"Color: {pair[1]} ");
                        break;

                    case "wheels":
                        Console.Write($"Wheels: {pair[1]} ");
                        break;

                    case "brand":
                        Console.Write($"Brand: {pair[1]} ");
                        break;

                    case "type":
                        Console.Write($"Type: {pair[1]} ");
                        break;

                    default:
                        Console.Write(error);
                        break;
                }
            }
            Console.WriteLine();
        }

    }
}
