using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class QueryParser
    {
        // syntax: property1 value1, property2 value2, property3 value3
        public void Parse(string input) {

            StringSplitOptions splitOptions =
                StringSplitOptions.TrimEntries |
                StringSplitOptions.RemoveEmptyEntries;

            string[] queries = input.Split(',');

            foreach (string query in queries) {
                string[] pair = query.Split(' ', splitOptions);

                // properties: plate, color, wheels, brand
                switch (pair[0]) {

                    case "plate":
                        Console.WriteLine($"Plate: {pair[1]}");
                        break;

                    case "color":
                        Console.WriteLine($"Color: {pair[1]}");
                        break;

                    case "wheels":
                        Console.WriteLine($"Wheels: {pair[1]}");
                        break;

                    case "brand":
                        Console.WriteLine($"Brand: {pair[1]}");
                        break;

                    default:
                        // handle errors in input here
                        break;
                }
            }
        }

    }
}
