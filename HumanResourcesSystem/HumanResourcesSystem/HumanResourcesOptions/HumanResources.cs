namespace HumanResourcesSystem.HumanResourcesOptions
{
    using System;
    using System.Collections.Generic;
    using ProjectInfo;

    public static class HumanResources
    {
        //This list contains all emlpoyees in company.
        private static List<Employee> allEmployees = new List<Employee>();
        //Employee ID
        private static int nextId = 1;

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
            newEmployee.EmployeeId = nextId;
            allEmployees.Add(newEmployee);
            nextId++;
        }
        // This method return list of all employee.
        public static List<Employee> GetEmployees()
        {
            return allEmployees;
        }
        //Print all emlpoyee.
        public static void PrintAllEmployee()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            if (allEmployees.Count < 1)
            {
                Console.WriteLine("No employees hired yet.");
            }
            else
            {
                Console.WriteLine("List of all employees:");
                foreach (var emp in allEmployees)
                {
                    Console.WriteLine("Name: {0} {1}, Position: {2}, ProjectID: {3}, Salary: ${4}, EmployeeID: {5}", emp.FirstName, emp.LastName, emp.PositionAtWork, emp.Project, emp.Salary, emp.EmployeeId);
                }
            }
        }
    }
}
