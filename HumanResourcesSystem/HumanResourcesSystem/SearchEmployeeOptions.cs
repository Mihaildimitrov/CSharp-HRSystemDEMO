

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
                case "1": HumanResources.PrintAllEmployee(); break;
                case "2": ProjectManagement.PrintAllProjects(); break;
                case "3": EmployeeWorkingProject(); break;
                case "4": ImmediateSuperior(); break;
                case "5": SearchByName(); break;
                case "6": EndSearchOptions(); break;
                default: Console.WriteLine("Please, select from the available options."); ; break;
            }
        }

        private static void ImmediateSuperior()
        {
            HumanResources.PrintAllEmployee();
            //Pick employeeId
            Console.Write("Please select employee ID: ");
            int employeeIDForSelect = int.Parse(Console.ReadLine());
            foreach (var employee in HumanResources.allEmployees)
	        {
	            	if (employeeIDForSelect == employee.EmployeeId)
	                {
		                // pick employee position
                        string positionEmployee = employee.PositionAtWork;
                        CheckSuperior(positionEmployee.ToLower());
	                } 

	        }
        }

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
            }
        }

        private static void SearchByName()
        {
            Console.Write("Please enter the firstname and the lastname of employee:");
            string employeeName = Console.ReadLine();

            foreach (var employee in HumanResources.allEmployees)
            {
                if (employeeName == employee.FirstName + employee.LastName)
                {
                    Console.WriteLine("Employee with this name exist");
                    Console.WriteLine("Name: {0} {1}, Position: {2}, ProjectID: {3}, Salary: ${4}, EmployeeID: {5}",
                        employee.FirstName, employee.LastName, employee.PositionAtWork, employee.Project, employee.Salary, employee.EmployeeId);
                }
                else
                {
                    Console.WriteLine("Employee with this name does not exist");
                }
            }



        }

        private static void EndSearchOptions()
        {
            endSearch = false;
            Console.WriteLine("The end of search!");
        }

        private static void EmployeeWorkingProject()
        {
            ProjectManagement.PrintAllProjects();
            //Pick project ID
            var allprojects = ProjectManagement.GetProjects();
            Console.Write("Please select project ID: ");
            int selectProjectId = int.Parse(Console.ReadLine());
            foreach (var project in allprojects)
            {
                if (selectProjectId == project.ProjectId)
                {
                    Console.WriteLine("These employees work on the project:");
                    foreach (var employee in project.AssignedEmployees)
                    {
                        Console.WriteLine("{0} {1} ", employee.FirstName, employee.LastName);
                    }
                }
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
