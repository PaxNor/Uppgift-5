using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_5.Vehicles;
using Uppgift_5.Interfaces;

/*
 * Sköter meny val och delegerar mellan UI och GarageHandler
 */

namespace Uppgift_5
{
    internal class Manager
    {
        private bool isRunning;
        private string? choice;
        private IGarageHandler handler;
        private IUI ui;

        public Manager() {
            handler = new GarageHandler();
            ui = new UI();
        }

        public void Start(Garage<Vehicle> garage) {

            handler.InitWithGarage(garage); // <-- temporary hack?
            isRunning = true;

            while(isRunning) {
                choice = ui.MenuPicker();

                switch (choice) {
                    case "1":
                        ui.ParkVehicle(handler);
                        break;

                    case "2":
                        ui.ShowStats(handler);
                        break;

                    case "3":
                        ui.FindVehicle(handler);
                        break;
                        
                    case "4":
                        ui.RemoveVehicle(handler);
                        break;

                    case "5":
                        handler.ListVehicles(ui);
                        break;

                    case "6":
                        ui.SearchByProperty(handler);
                        break;

                    case "7":
                        ui.ShowFreeSpace(handler);
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
