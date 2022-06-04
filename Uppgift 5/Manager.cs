using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5
{
    internal class Manager
    {
        private bool isRunning;
        private string? choice;
        private GarageHandler garageHandler;
        private UI ui;

        public Manager() {
            garageHandler = new GarageHandler();
            ui = new UI();
        }

        public void Start(Garage<Vehicle> garage) {

            garageHandler.InitWithGarage(garage); // <-- temporary hack?
            isRunning = true;

            while(isRunning) {
                choice = ui.MenuPicker();

                switch (choice) {
                    case "1":
                        ui.ParkVehicle(garageHandler);
                        break;

                    case "2":
                        ui.ShowStats(garageHandler);
                        break;

                    case "3":
                        ui.FindVehicle(garageHandler);
                        break;
                        
                    case "4":
                        ui.RemoveVehicle(garageHandler);
                        break;

                    case "5":
                        garageHandler.ListVehicles(ui);
                        break;

                    case "6":
                        ui.SearchByProperty(garageHandler);
                        break;

                    case "7":
                        ui.ShowFreeSpace(garageHandler);
                        break;

                    case "8":
                        isRunning = false;
                        break;

                    default:
                        ui.ReportError("Invalid choice");
                        break;
                }
            }
        }
    }
}
