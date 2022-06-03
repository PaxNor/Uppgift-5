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
     * 
     * This may be moved into the UI class eventually..
     */

    internal static class UIExtension
    {
        public static Vehicle CreateVehicle(this UI ui) {
            
            string type = IOUtil.runUserDialog("Enter vehicle type: ", "car", "bus", "motorcycle", "boat", "airplane");
            string licensePlate = IOUtil.runUserDialog("Enter license plate: ");
            string color = IOUtil.runUserDialog("Enter color: ");
            string brand = IOUtil.runUserDialog("Enter brand: ");
            uint wheelCount = IOUtil.runUserDialogNumeric("Enter wheel count: ");
            string subType;

            switch (type.ToLower()) {

                case "car":
                    subType = IOUtil.runUserDialog("Enter model (sedan, coupe, pickup suv): ", "sedan", "coupe", "convertible", "pickup", "suv");
                    Car.SubType carType = (Car.SubType)Enum.Parse(typeof(Car.SubType), subType, true);
                    return new Car(licensePlate, wheelCount, color, brand, carType);

                case "bus":
                    uint seatCount = IOUtil.runUserDialogNumeric("Enter seat count: ");
                    uint weight = IOUtil.runUserDialogNumeric("Enter weight: ");
                    return new Bus(licensePlate, wheelCount, color, brand, seatCount, weight);

                case "motorcycle":
                    subType = IOUtil.runUserDialog("Enter model (offroad, sport, classic): ", "offroad", "sport", "classic");
                    uint speed = IOUtil.runUserDialogNumeric("Enter top speed: ");
                    Motorcycle.SubType motorcycleType = (Motorcycle.SubType)Enum.Parse(typeof(Motorcycle.SubType), subType, true);
                    return new Motorcycle(licensePlate, wheelCount, color, brand, speed, motorcycleType);

                case "boat":
                    uint length = IOUtil.runUserDialogNumeric("Enter length: ");
                    return new Boat(licensePlate, wheelCount, color, brand, length);

                case "airplane":
                    uint wingspan = IOUtil.runUserDialogNumeric("Enter wingspan: ");
                    return new Airplane(licensePlate, wheelCount, color, brand, wingspan);

                default:
                    // this can't happen
                    throw new Exception("Attempt at creating a vehicle type that does not exist.");
            }
        }

    }
}
