

namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SearchEmployeeOptions
    {
        public static bool endSearch = true;
        public static void SearchOptions()
        {
            string selectedSearchOptions;

            do
            {
                SearchMenu();
                selectedSearchOptions = Console.ReadLine();

                HandleSearchInput(selectedSearchOptions);
                
            } while (endSearch);



        }

        private static void HandleSearchInput(string selectedSearchOptions)
        {
            switch (selectedSearchOptions)
            {
                case "1": ; break;
                case "2": ; break;
                case "3": ; break;
                case "4": ; break;
                case "5": ; break;
                case "6": ; break;
                default: ; break;
            }
        }

        private static void SearchMenu()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("Please, select from the following options:");
            Console.WriteLine("1. Print all employee.");
            Console.WriteLine("2. Print all projects.");
            Console.WriteLine("3. Print all working on the project.");
            Console.WriteLine("4. Print immediate superior.");
            Console.WriteLine("5. Search employee by name");
            Console.WriteLine("6. To end search");
            Console.Write("The program expects your input: ");
        }

    }
}
