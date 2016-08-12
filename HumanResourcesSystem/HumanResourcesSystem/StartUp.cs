namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProjectInfo;
    using HumanResourcesOptions;

    class StartUp
    {
        private static bool endProgram = true;
        static void Main()
        {
            string selectedCommand;
            do
            {
                //Print main menu
                PrintMainMenu();
                // main logic program.
                selectedCommand = Console.ReadLine();
                HandleInput(selectedCommand);
                
            } while (endProgram);
        }

        
        // Main method program. This method handle user input.
        private static void HandleInput(string selectedCommand)
        {
            if (selectedCommand == "1")
            {
                HumanResources.HireEmployee();
            }
            else if (selectedCommand == "2")
            {
                EditHumanResources.EditEmployee();
            }
            else if (selectedCommand == "3")
            {
                SearchOptions.SearchingOptions();
            }
            else if (selectedCommand == "4")
            {
                EndManagementSystem();   
            }
            else
            {
                Console.WriteLine("Please, select from the available options.");
                PrintCommand();
                Console.ReadKey();
            }

            //switch (selectedCommand)
            //{
            //    case "1": HumanResources.HireEmployee(); break;
            //    case "2": EditHumanResources.EditEmployee(); break;
            //    case "3": SearchOptions.SearchingOptions(); break;
            //    case "4": EndManagementSystem(); break;
            //    default: Console.WriteLine("Please, select from the available options."); break;
            //}
        }
        //method which stop the program.
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
            Console.WriteLine("3. For search and print options.");
            Console.WriteLine("4. For end of program.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The program expects your input: ");
        }

        public static void PrintCommand()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Press any key to continue:");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
