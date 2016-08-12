namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;
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

        // method which print immediate superior of two employees.
        private static void ImmediateSuperior()
        {
            Console.Clear();
            var allEmp = HumanResources.GetEmployees();
            if (allEmp.Count < 1)
            {
                Console.WriteLine("No such employee!");
                StartUp.PrintCommand();
                Console.ReadKey();
            }
            if (allEmp.Count == 1)
            {
                Console.WriteLine("Have only one employee!");
                StartUp.PrintCommand();
                Console.ReadKey();
            }
            HumanResources.PrintAllEmployee();
            //Pick employeesId.
            Employee currentFirstEmployee = new Employee();
            Employee currentSecondEmployee = new Employee();
            Console.WriteLine("Please select employees ID: ");
            Console.Write("Please enter ID of the first employee: ");
            int empFirstID = int.Parse(Console.ReadLine());
            Console.Write("Please enter ID of the second employee: ");
            int empSecondID = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (var emp in allEmp)
            {
                if (emp.EmployeeId == empFirstID)
                {
                    currentFirstEmployee = emp;
                }
                if (emp.EmployeeId == empSecondID)
                {
                    currentSecondEmployee = emp;
                }
            }
            CheckSuperior(currentFirstEmployee, currentSecondEmployee);
        }

        // method print immediate superior.
        private static void CheckSuperior(Employee currentFirstEmployee, Employee currentSecondEmployee)
        {
            int convertedPositionFirstEmp = ConvertPositionAtWork(currentFirstEmployee.PositionAtWork.ToLower());
            int convertedPositionSecondEmp = ConvertPositionAtWork(currentSecondEmployee.PositionAtWork.ToLower());
            // If work on the same project
            if (currentFirstEmployee.Project == currentSecondEmployee.Project)
            {
                int workingProjectId = currentFirstEmployee.Project;
                int higherPosition = 0;
                //If both employee is between trainee and senior
                if (convertedPositionFirstEmp == 4 && convertedPositionSecondEmp == 4)
                {
                    higherPosition = 5;
                    var listEmployee = HumanResources.GetEmployees();
                    foreach (var emp in listEmployee)
                    {
                        if (emp.Project == workingProjectId)
                        {
                            if (emp.PositionAtWork == "Team lead")
                            {
                                Console.WriteLine("Their superior is Team lead with name {0}", emp.FirstName + " " + emp.LastName);
                            }
                        }
                    }
                }
                else // If employee position is different or same.
                {
                    if (convertedPositionFirstEmp > convertedPositionSecondEmp)
                    {
                        higherPosition = convertedPositionFirstEmp + 1;
                        PrintSuperior(higherPosition, workingProjectId);
                    }
                    if (convertedPositionSecondEmp >= convertedPositionFirstEmp)
                    {
                        higherPosition = convertedPositionSecondEmp + 1;
                        PrintSuperior(higherPosition, workingProjectId);
                    }
                }
            }
            // If work on the different projects
            int firstEmpProj = currentFirstEmployee.Project;
            int secondEmpProj = currentSecondEmployee.Project;
            var allProj = ProjectManagement.GetProjects();
            string firstEmpProjectDeliveryDirector = null;
            string secondEmpProjectDeliveryDirector = null;
            if (currentFirstEmployee.Project != currentSecondEmployee.Project)
            {
                // If both employees is not a Delivery director.
                if (convertedPositionFirstEmp < 7 && convertedPositionSecondEmp < 7)
                {
                    foreach (var proj in allProj)
                    {
                        if (firstEmpProj == proj.ProjectId)
                        {
                            firstEmpProjectDeliveryDirector = proj.DeliveryDirectorName;
                        }
                        if (secondEmpProj == proj.ProjectId)
                        {
                            secondEmpProjectDeliveryDirector = proj.DeliveryDirectorName;
                        }
                    }
                    // if both DD is same, Print superior is Delivery director
                    if (firstEmpProjectDeliveryDirector == secondEmpProjectDeliveryDirector)
                    {
                        Console.WriteLine("Their superior is Delivery director with name {0}", firstEmpProjectDeliveryDirector);
                    }
                    // If both DD is different Print superior is CEO
                    else
                    {
                        Console.WriteLine("Their superior is CEO with name Richard Brown");
                    }
                }
                // If one of the two employees is Delivery director.
                if (convertedPositionFirstEmp == 7 || convertedPositionSecondEmp == 7)
                {
                    //Print superior is CEO
                    Console.WriteLine("Their superior is CEO with name Richard Brown");
                }
            }
        }

        // This method print superior of two employees.
        private static void PrintSuperior(int higherPosition, int workingProjectId)
        {
            if (higherPosition == 8)
            {
                Console.WriteLine("Their superior is CEO with name Richard Brown");
            }
            else
            {
                var listEmployee = HumanResources.GetEmployees();
                string position = null;
                switch (higherPosition)
                {
                    case 6: position = "Project manager"; break;
                    case 7: position = "Delivery director"; break;
                }
                foreach (var emp in listEmployee)
                {
                    if (emp.Project == workingProjectId)
                    {
                        if (emp.PositionAtWork == position)
                        {
                            Console.WriteLine("Their superior is {0} with name {1}", position, emp.FirstName + " " + emp.LastName);
                        }
                    }
                }
            }
        }

        // This method converted employye position in number.
        private static int ConvertPositionAtWork(string pos)
        {
            int empPositionNumber = 0;
            switch (pos)
            {
                case "trainee": empPositionNumber = 4; break;
                case "junior":empPositionNumber = 4; break;
                case "intermediate":empPositionNumber = 4; break;
                case "senior":empPositionNumber = 4; break;
                case "team leader":empPositionNumber = 5; break;
                case "project manager":empPositionNumber = 6; break;
                case "delivery director":empPositionNumber = 7; break;
                case "ceo":empPositionNumber = 8; break;
            }
            return empPositionNumber;
        }

        // this method searching in list of employee by name.
        private static void SearchByName()
        {
            Console.Clear();
            // Enter name for search.
            Console.Write("Please enter the first name and the last name of employee separated by space:");
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
                            Console.WriteLine("{0} {1} - {2}",employee.FirstName, employee.LastName, employee.PositionAtWork);
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
            Console.WriteLine("3. Print all employees working on the project.");
            Console.WriteLine("4. Print immediate superior of two employees.");
            Console.WriteLine("5. Search employee by name");
            Console.WriteLine("6. To end search");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The program expects your input: ");
        }
    }
}
