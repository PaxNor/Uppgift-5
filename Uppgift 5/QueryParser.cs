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
        public List<string[]>? Parse(string input) {

            StringSplitOptions splitOptions =
                StringSplitOptions.TrimEntries |
                StringSplitOptions.RemoveEmptyEntries;

            List<string[]> queries = new List<string[]>();
            //input = input.ToLower();
            string[] pairs = input.Split(',');

            foreach (string pair in pairs) {
                string[] keyValue = pair.Split(' ', splitOptions);

                // ignore empty lines
                if (keyValue.Length == 0) {
                    queries.Add(keyValue);
                    return queries;
                }

                if (keyValue.Length != 2) return null;
                else queries.Add(keyValue);
            }

            return queries;
        }
    }
}
