using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Hanterar användar io, validering, parsning och 
 * formatering av strängar från användaren.
 */

namespace Uppgift_5.Auxilary
{

    static class IOUtil
    {
        // removes white space and convert to upper case
        public static string CompactUserString(string userString) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in userString) {
                if (char.IsWhiteSpace(c) == false) {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToUpper();
        }

        // syntax: property1 value1, property2 value2, property3 value3
        // returns: list of key/value pairs in string arrays
        public static List<string[]>? ParseQuery(string input) {

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

        // performs question - answer user dialog, re-asks on null
        public static string runUserDialog(string output) {
            string? result;
            do {
                Console.Write(output);
                result = Console.ReadLine();
            } while (result == null);

            return result;
        }

        // performs user dialog until user answer is part of 'accepted[]'
        public static string runUserDialog(string output, params string[] accepted) {
            bool isValid = false;
            string result;

            do {
                result = runUserDialog(output);
                foreach (string option in accepted) {
                    if (result.ToLower() == option.ToLower()) isValid = true;
                }
            } while (isValid == false);

            return result;
        }

        // validates and returns an unsigned integer
        public static uint runUserDialogNumeric(string output) {
            bool isValid = false;
            string stringResult;
            uint result;

            do {
                stringResult = runUserDialog(output);
                isValid = uint.TryParse(stringResult, out result);
            } while (isValid == false);

            return result;
        }

    }
}
