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
                Console.Clear();
                HumanResources.PrintAllEmployee();
                StartUp.PrintCommand();
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear(); 
            }
            else if (selectedCommand == "3")
            {
                Console.Clear();
                ProjectManagement.PrintAllProjects();
                StartUp.PrintCommand();
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear(); 
            }
            else if (selectedCommand == "4")
            {
                HumanResources.EditEmployeeProject();
            }
            else if (selectedCommand == "5")
            {
                SearchDirectsSuperior.ImmediateSuperior();
                PrintCommand();
                Console.ReadKey();
            }
            else if (selectedCommand == "6")
            {
                EndManagementSystem();   
            }
            else
            {
                Console.WriteLine("Please, select from the available options.");
                PrintCommand();
                Console.ReadKey();
            }
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
            Console.WriteLine("2. For print all employee.");
            Console.WriteLine("3. For print all projects.");
            Console.WriteLine("4. For assign employee in given project.");
            Console.WriteLine("5. For print direct superior.");
            Console.WriteLine("6. For end of program.");
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
