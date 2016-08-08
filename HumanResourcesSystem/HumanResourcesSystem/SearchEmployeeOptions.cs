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
            Console.Clear();
            string selectedSearchOptions;
            do
            {
                SearchMenu();
                //current selected option.
                selectedSearchOptions = Console.ReadLine();
                HandleSearchInput(selectedSearchOptions);
            } while (endSearch);
        }
        // search menu method.
        private static void HandleSearchInput(string selectedSearchOptions)
        {
            switch (selectedSearchOptions)
            {
                case "1": Console.Clear(); 
                    HumanResources.PrintAllEmployee();
                    Console.Write("Press any key to continue:");
                    Console.ReadKey(); 
                    break;
                case "2": Console.Clear();
                    ProjectManagement.PrintAllProjects();
                    Console.Write("Press any key to continue:");
                    Console.ReadKey(); 
                    break;
                case "3": EmployeeWorkingProject(); break;
                case "4": ImmediateSuperior(); break;
                case "5": SearchByName(); break;
                case "6": EndSearchOptions(); break;
                default: Console.WriteLine("Please, select from the available options."); ; break;
            }
        }
        // method which print immediate superior of any employee.
        private static void ImmediateSuperior()
        {
            Console.Clear();
            HumanResources.PrintAllEmployee();
            //Pick employeeId.
            Console.Write("Please select employee ID: ");
            int employeeIDForSelect = int.Parse(Console.ReadLine());
            if (employeeIDForSelect > HumanResources.allEmployees.Count)
            {
                Console.WriteLine("No such employee!");
                Console.Write("Press any key to continue:");
                Console.ReadKey();
            }
            foreach (var employee in HumanResources.allEmployees)
	        {
	            	if (employeeIDForSelect == employee.EmployeeId)
	                {
		                // pick employee position.
                        string positionEmployee = employee.PositionAtWork;
                        //check superior.
                        CheckSuperior(positionEmployee.ToLower());
	                }
	        }
            
        }
        // method print immediate superior.
        private static void CheckSuperior(string positionEmployee)
        {
            switch (positionEmployee)
            {
                case "trainee": Console.WriteLine("His supervisor is \"Team leader\""); break;
                case "junior": Console.WriteLine("His supervisor is \"Team leader\""); break;
                case "intermediate": Console.WriteLine("His supervisor is \"Team leader\""); break;
                case "senior": Console.WriteLine("His supervisor is \"Team leader\""); break;
                case "team leader": Console.WriteLine("His supervisor is \"Project manager\""); break;
                case "project manager": Console.WriteLine("His supervisor is \"Delivery director\""); break;
                case "delivery director": Console.WriteLine("His supervisor is \"CEO\""); break;
                case "ceo": Console.WriteLine("He has no supervisor"); break;
                default: Console.WriteLine("This employee position does not exist in the company."); break;
            }
            Console.Write("Press any key to continue:");
            Console.ReadKey();
        }
        // this method searching in list employee by name.
        private static void SearchByName()
        {
            Console.Clear();
            // Enter name for search.
            Console.Write("Please enter the firstname and the lastname of employee:");
            string employeeName = Console.ReadLine();
            // Check the name exist.
            foreach (var employee in HumanResources.allEmployees)
            {
                if (employeeName == employee.FirstName + employee.LastName)
                {
                    Console.WriteLine("Employee with this name exist");
                    Console.WriteLine("Name: {0} {1}, Position: {2}, ProjectID: {3}, Salary: ${4}, EmployeeID: {5}",
                        employee.FirstName, employee.LastName, employee.PositionAtWork, employee.Project, employee.Salary, employee.EmployeeId);
                    Console.Write("Press any key to continue:");
                    Console.ReadKey();
                }
                    // If the name does not exist.
                else
                {
                    Console.WriteLine("Employee with this name does not exist");
                    Console.Write("Press any key to continue:");
                    Console.ReadKey();
                }
            }
        }
        // This method end search method.
        private static void EndSearchOptions()
        {
            endSearch = false;
            Console.WriteLine("The end of search!");
        }
        private static void EmployeeWorkingProject()
        {
            Console.Clear();
            ProjectManagement.PrintAllProjects();
            //Pick project ID
            var allprojects = ProjectManagement.GetProjects();
            Console.Write("Please select project ID: ");
            int selectProjectId = int.Parse(Console.ReadLine());
            foreach (var project in allprojects)
            {
                //Check whether any work on the project.
                if (selectProjectId == project.ProjectId)
                {
                    if (project.AssignedEmployees.Count >= 1)
                    {
                        Console.WriteLine("These employees work on the project:");
                        foreach (var employee in project.AssignedEmployees)
                        {
                            Console.WriteLine("{0} {1} ", employee.FirstName, employee.LastName);
                        }
                        Console.Write("Press any key to continue:");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No employees work on the project.");
                        Console.Write("Press any key to continue:");
                        Console.ReadKey();
                    }
                }
            }
        }
        // Print search menu.
        private static void SearchMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, select from the following options:");
            Console.WriteLine("1. Print all employee.");
            Console.WriteLine("2. Print all projects.");
            Console.WriteLine("3. Print all working on the project.");
            Console.WriteLine("4. Print immediate superior.");
            Console.WriteLine("5. Search employee by name");
            Console.WriteLine("6. To end search");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The program expects your input: ");
        }

    }
}
