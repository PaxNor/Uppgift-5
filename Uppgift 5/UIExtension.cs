using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{   
    /*
     * Added this as an extension to the UI class since
     * it takes up a lot of space while only dealing with
     * creating and validating the creation of a vehicle.
     */

    internal static class UIExtension
    {
        // performs question - answer user dialog, re-asks on null
        private static string runUserDialog(string output) {
            string? result;
            do {
                Console.Write(output);
                result = Console.ReadLine();
            } while (result == null);

            return result;
        }

        // performs user dialog until user answer is part of 'accepted[]'
        private static string runUserDialog(string output, params string[] accepted) {
            bool isValid = false;
            string result;

            do {
                result = runUserDialog(output);
                foreach(string option in accepted) {
                    if (result.ToLower() == option.ToLower()) isValid = true;
                }
            } while(isValid == false);

            return result;
        }

        public static void AddVehicle(this UI ui) {

            string type = runUserDialog("Enter vehicle type: ", "car", "bus", "motorcycle", "boat", "airplane");
            string licensePlate = runUserDialog("Enter license plate: ");
            string color = runUserDialog("Enter color: ");
            string brand = runUserDialog("Enter brand: ");
            string wheelCount = runUserDialog("Enter wheel count: ");
            string subType;

            switch (type.ToLower()) {

                case "car":
                    subType = runUserDialog("Enter model (sedan, coupe, pickup suv): ", "sedan", "coupe", "pickup", "suv");
                    // create car
                    break;

                case "bus":
                    string seatCount = runUserDialog("Enter seat count: ");
                    string weight = runUserDialog("Enter weight: ");
                    // create bus
                    break;

                case "motorcycle":
                    subType = runUserDialog("Enter model (offroad, sport, classic): ");
                    string speed = runUserDialog("Enger top speed: ", "offroad", "sport", "classic");
                    // create motorcycle
                    break;

                case "boat":
                    string length = runUserDialog("Enter length: ");
                    // create boat
                    break;

                case "airplane":
                    string wingspan = runUserDialog("Enter wingspan: ");
                    // create airplane
                    break;

                default:
                    // this can't happen
                    throw new Exception("Attempt at creating a vehicle type that does not exist.");
            }
        }

    }
}
