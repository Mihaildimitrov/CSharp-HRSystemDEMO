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
                PrintMainMenu();
                selectedCommand = Console.ReadLine();

                try
                {
                    HandleInput(selectedCommand);
                }
                catch (Exception)
                {
                    
                    throw;
                }

            } while (endProgram);
        }

        private static void HandleInput(string selectedCommand)
        {
            switch (selectedCommand)
            {
                case "1": HumanResources.HireEmployee(); break;
                case "2": EditHumanResources.EditEmployee(); break;
                case "3": ; break;
                case "4": EndManagementSystem(); break;
                default: Console.WriteLine("Please, select from the available options."); break;
            }
        }

        private static void EndManagementSystem()
        {
            endProgram = false;
            Console.WriteLine("The application was stopped!");
        }

        

        public static void PrintMainMenu()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("Please, select from the following options:");
            Console.WriteLine("1. For apointed staff.");
            Console.WriteLine("2. For edit information for employee.");
            Console.WriteLine("3. For looking at the list of employees.");
            Console.WriteLine("4. For end of program.");
            Console.Write("The program expects your input: ");
        }

    }
}
