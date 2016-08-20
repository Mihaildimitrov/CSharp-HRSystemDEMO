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
            string selectedCommandOfHr;
            do
            {
                //Print main menu.
                PrintMainMenu();
                // Main logic program.
                selectedCommandOfHr = Console.ReadLine();
                HandleInput(selectedCommandOfHr);
                
            } while (endProgram);
        }
        // Main method program. This method handle user input.
        private static void HandleInput(string selectedCommandOfHr)
        {
            if (selectedCommandOfHr == "1")
            {
                HumanResources.HireEmployee();
            }
            else if (selectedCommandOfHr == "2")
            {
                Console.Clear();
                HumanResources.PrintAllEmployee();
                StartUp.PrintCommand();
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear(); 
            }
            else if (selectedCommandOfHr == "3")
            {
                Console.Clear();
                ProjectManagement.PrintAllProjects();
                StartUp.PrintCommand();
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear(); 
            }
            else if (selectedCommandOfHr == "4")
            {
                HumanResources.EditEmployeeProject();
            }
            else if (selectedCommandOfHr == "5")
            {
                SearchDirectsSuperior.ImmediateSuperior();
                PrintCommand();
                Console.ReadKey();
            }
            else if (selectedCommandOfHr == "6")
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
        //Method which stop the program.
        private static void EndManagementSystem()
        {
            endProgram = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The application was stopped!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Method which print main menu.
        public static void PrintMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, select from the following options:");
            Console.WriteLine("1. Add employee.");
            Console.WriteLine("2. Print all employee.");
            Console.WriteLine("3. Print all projects.");
            Console.WriteLine("4. Assign employee in given project.");
            Console.WriteLine("5. Print direct superior.");
            Console.WriteLine("6. End of program.");
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
