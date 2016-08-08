using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesSystem
{
    class StartUp
    {
        public static bool endProgram = true;
        static void Main()
        {
            string selectedCommand;
            do
            {
                //Print main menu
                PrintMainMenu();
                // main logic program.
                selectedCommand = Console.ReadLine();
                try
                {
                    HandleInput(selectedCommand);
                }
                catch (ArgumentNullException exMesage)
                {
                    Console.WriteLine(exMesage.Message);
                }
            } while (endProgram);
        }
        // Main method program.
        private static void HandleInput(string selectedCommand)
        {
            switch (selectedCommand)
            {
                case "1": HumanResources.HireEmployee(); break;
                case "2": EditHumanResources.EditEmployee(); break;
                case "3": SearchEmployeeOptions.SearchOptions(); break;
                case "4": EndManagementSystem(); break;
                default: Console.WriteLine("Please, select from the available options."); break;
            }
        }
        //method which end the program.
        private static void EndManagementSystem()
        {
            endProgram = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The application was stopped!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // method which print main menu.
        public static void PrintMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, select from the following options:");
            Console.WriteLine("1. For add employee.");
            Console.WriteLine("2. For edit information for employee.");
            Console.WriteLine("3. For options search in employees and projects.");
            Console.WriteLine("4. For end of program.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The program expects your input: ");
        }

    }
}
