namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProjectInfo;
    using HumanResourcesOptions;

    public static class SearchOptions
    {
        public static bool endSearch = true;
        public static void SearchingOptions()
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
                    StartUp.PrintCommand();
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.Clear(); 
                    break;
                case "2": Console.Clear();
                    ProjectManagement.PrintAllProjects();
                    StartUp.PrintCommand();
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.Clear(); 
                    break;
                case "3": EmployeeWorkingProject(); break;
                case "4": ImmediateSuperior(); break;
                case "5": SearchByName(); break;
                case "6": EndSearchOptions(); break;
                default: 
                    Console.WriteLine("Please, select from the available options.");
                    StartUp.PrintCommand();
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
        // method which print immediate superior of any employee.
        private static void ImmediateSuperior()
        {
            Console.Clear();
            HumanResources.PrintAllEmployee();
            //Pick employeeId.
            Console.Write("Please select employee ID: ");
            var listEmployee = HumanResources.GetEmployees();
            int employeeIDForSelect = int.Parse(Console.ReadLine());
            if (employeeIDForSelect > listEmployee.Count)
            {
                Console.WriteLine("No such employee!");
                StartUp.PrintCommand();
                Console.ReadKey();
            }
            foreach (var employee in listEmployee)
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
            //*********************************************
            // New logic
            // first should print the list of all employees!!!
            Employee currentFirstEmployee = new Employee();
            Employee currentSecondEmployee = new Employee();

            var allEmp = HumanResources.GetEmployees();
            Console.WriteLine("Please enter ID of the first employee");
            int empFirstID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter ID of the second employee");
            int empSecondID = int.Parse(Console.ReadLine());
            foreach (var emp in allEmp)
            {
                if (emp.EmployeeId == empFirstID)
                {
                    currentFirstEmployee = emp;
                    //break;
                }
                if (emp.EmployeeId == empSecondID)
                {
                    currentSecondEmployee = emp;
                    //break;
                }
            }
            //string firstEmpPosition = currentFirstEmployee.PositionAtWork;
            //string secondEmpPosition = currentSecondEmployee.PositionAtWork;
            int convertedPositionFirstEmp = ConvertPositionAtWork(currentFirstEmployee.PositionAtWork);
            int convertedPositionSecondEmp = ConvertPositionAtWork(currentSecondEmployee.PositionAtWork);
            // ConvertPositionAtWork() is method 
            // If work on the same project
            if (currentFirstEmployee.Project == currentSecondEmployee.Project)
            {
                //If both employee is between trainee and senior
                if ((convertedPositionFirstEmp >=1 && convertedPositionFirstEmp <= 4) && (convertedPositionSecondEmp >= 1 && convertedPositionSecondEmp <= 4))
                {
                    //print superior is team lead
                }
                // If employee position is different
                if (true)
                {
                    
                }
            }

                

            
            // End new logic
            //*********************************************
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
            StartUp.PrintCommand();
            Console.ReadKey();
            Console.WriteLine();
            Console.Clear(); 
        }

        private static int ConvertPositionAtWork(string pos)
        {
            int empPositionNumber = 0;

            switch (pos)
            {
                case "trainee": empPositionNumber = 1; break;
                case "junior":empPositionNumber = 2; break;
                case "intermediate":empPositionNumber = 3; break;
                case "senior":empPositionNumber = 4; break;
                case "team leader":empPositionNumber = 5; break;
                case "project manager":empPositionNumber = 6; break;
                case "delivery director":empPositionNumber = 7; break;
                case "ceo":empPositionNumber = 8; break;
            }
            return empPositionNumber;
        }

        private static void GetSuperiorSameProject()
        {
            
        }



        // this method searching in list employee by name.
        private static void SearchByName()
        {
            Console.Clear();
            // Enter name for search.
            Console.Write("Please enter the firstname and the lastname of employee:");
            string employeeName = Console.ReadLine();
            var listEmployee = HumanResources.GetEmployees();
            bool exist = false;
            // Check the name exist.
            foreach (var employee in listEmployee)
            {
                if (employeeName.ToLower() == employee.FirstName.ToLower() + " " + employee.LastName.ToLower())
                {
                    exist = true;
                    Console.WriteLine("Employee with this name exist:");
                    Console.WriteLine("Name: {0} {1}, Position: {2}, WorkingProjectID: {3}, Salary: ${4}, EmployeeID: {5}",
                        employee.FirstName, employee.LastName, employee.PositionAtWork, employee.Project, employee.Salary, employee.EmployeeId);
                    StartUp.PrintCommand();
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.Clear();
                }
            }
            // If the name does not exist.
            if (!exist)
            {
                Console.WriteLine("Employee with this name does not exist");
                StartUp.PrintCommand();
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
            }
        }
        // This method stops search method.
        private static void EndSearchOptions()
        {
            endSearch = false;
            Console.WriteLine("The end of search!");
        }
        //Method checks if some work on the project.
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
                        StartUp.PrintCommand();
                        Console.ReadKey();
                        Console.WriteLine();
                        Console.Clear(); 
                    }
                    else
                    {
                        Console.WriteLine("No employees work on the project.");
                        StartUp.PrintCommand();
                        Console.ReadKey();
                        Console.WriteLine();
                        Console.Clear(); 
                    }
                }
            }
        }
        // Print search menu.
        private static void SearchMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, select from the following options:");
            Console.WriteLine("1. Print all employee.");
            Console.WriteLine("2. Print all projects.");
            Console.WriteLine("3. Print all working on the project.");
            Console.WriteLine("4. Print immediate superior.");
            Console.WriteLine("5. Search employee by name");
            Console.WriteLine("6. To end search");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The program expects your input: ");
        }

    }
}
