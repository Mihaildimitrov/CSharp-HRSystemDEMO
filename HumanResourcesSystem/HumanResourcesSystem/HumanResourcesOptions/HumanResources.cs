namespace HumanResourcesSystem.HumanResourcesOptions
{
    using System;
    using System.Collections.Generic;
    using ProjectInfo;

    public static class HumanResources
    {
        //This list contains all emlpoyees in company.
        private static List<Employee> allEmployeesInCompany = new List<Employee>()
        {
            new Employee {FirstName = "William", LastName = "Smith", PositionAtWork = "trainee", Project = 1, EmployeeId = 1 },
            new Employee {FirstName = "Daniel", LastName = "Lee", PositionAtWork = "junior", Project = 1, EmployeeId = 2 },
            new Employee {FirstName = "Martin", LastName = "Lopez", PositionAtWork = "intermediate", Project = 1, EmployeeId = 3 },
            new Employee {FirstName = "Alexander", LastName = "Nelson", PositionAtWork = "senior", Project = 1, EmployeeId = 4 },
            new Employee {FirstName = "David", LastName = "Morris", PositionAtWork = "team leader", Project = 1, EmployeeId = 5 },
            new Employee {FirstName = "Sophia", LastName = "Gomez", PositionAtWork = "project manager", Project = 1, EmployeeId = 6 },
            new Employee {FirstName = "Emily", LastName = "Jackson", PositionAtWork = "delivery director", Project = 1, EmployeeId = 7 },
            new Employee {FirstName = "Erik", LastName = "Smith", PositionAtWork = "trainee", Project = 2, EmployeeId = 8 },
            new Employee {FirstName = "Viktor", LastName = "Lee", PositionAtWork = "junior", Project = 2, EmployeeId = 9 },
            new Employee {FirstName = "Vanq", LastName = "Ivanova", PositionAtWork = "intermediate", Project = 2, EmployeeId = 10 },
            new Employee {FirstName = "Kristian", LastName = "Krustanov", PositionAtWork = "senior", Project = 2, EmployeeId = 11 },
            new Employee {FirstName = "Julia", LastName = "Gomez", PositionAtWork = "team leader", Project = 2, EmployeeId = 12 },
            new Employee {FirstName = "Victoria", LastName = "Johnson", PositionAtWork = "project manager", Project = 2, EmployeeId = 13 },
            new Employee {FirstName = "Ryan", LastName = "Ortiz", PositionAtWork = "delivery director", Project = 2, EmployeeId = 14 }
        };
        //Employee ID.
        private static int nextIdOfEmployee = 15;
        // This method create employees.
        public static void HireEmployee()
        {
            Employee newEmployee = new Employee();
            // Form for create Employee.
            Console.Write("Please, enter the first name of the employee: ");
            newEmployee.FirstName = Console.ReadLine();
            Console.Write("Please, enter the last name of the employee: ");
            newEmployee.LastName = Console.ReadLine();
            Console.Write("Please, enter the employee position: ");
            newEmployee.PositionAtWork = Console.ReadLine();
            newEmployee.EmployeeId = nextIdOfEmployee;
            allEmployeesInCompany.Add(newEmployee);
            nextIdOfEmployee++;
        }

        // This method Assign employee in project.
        public static void EditEmployeeProject()
        {
            Console.Clear();
            //Print all projects in company.
            ProjectManagement.PrintAllProjects();
            //Print all employee in company.
            HumanResources.PrintAllEmployee();
            Console.WriteLine("Assign to project: ");
            //Pick project ID.
            Console.Write("Please select project ID: ");
            int selectProjectId = int.Parse(Console.ReadLine());
            //Pick employee Id.
            Console.Write("Please select employee ID:");
            int employeeIDForEditProject = int.Parse(Console.ReadLine());

            //Set project.
            var listEmployee = HumanResources.GetEmployees();
            foreach (var employee in listEmployee)
            {
                if (employee.EmployeeId == employeeIDForEditProject)
                {
                    employee.Project = selectProjectId;
                    ProjectManagement.AssignEmployee(selectProjectId, employee);
                }
            }
        }
        // This method return list of all employee in variable.
        public static List<Employee> GetEmployees()
        {
            return allEmployeesInCompany;
        }
        //Print all emlpoyee.
        public static void PrintAllEmployee()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            if (allEmployeesInCompany.Count < 1)
            {
                Console.WriteLine("No employees hired yet.");
            }
            else
            {
                Console.WriteLine("List of all employees:");
                foreach (var emp in allEmployeesInCompany)
                {
                    Console.WriteLine("Name: {0} {1}, Position: {2}, ProjectID: {3}, EmployeeID: {4}", emp.FirstName, emp.LastName, emp.PositionAtWork, emp.Project, emp.EmployeeId);
                }
            }
        }
    }
}
