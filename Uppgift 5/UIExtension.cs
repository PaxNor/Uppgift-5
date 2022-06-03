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

        private static bool validateVehicleType(string type) {
            switch(type.ToLower()) {
                case "car":         return true;
                case "bus":         return true;
                case "motorcycle":  return true;
                case "boat":        return true;
                case "airplane":    return true;
            }
            return false;
        }

        public static void AddVehicle(this UI ui) {

            string type;
            string licensePlate;
            string color;
            string brand;
            string wheelCount;
            string subType;

            type = runUserDialog("Enter vehicle type: ");
            if (validateVehicleType(type) == false) {
                Console.WriteLine("Invalid vehicle type");
                return;
            }

            licensePlate = runUserDialog("Enter license plate: ");
            color = runUserDialog("Enter color: ");
            brand = runUserDialog("Enter brand: ");
            wheelCount = runUserDialog("Enter wheel count: ");

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
