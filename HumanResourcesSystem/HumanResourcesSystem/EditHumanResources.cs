namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class EditHumanResources
    {
        public static bool endOfEdit = true;
        //Method for edit employee.
        public static void EditEmployee()
        {
            string selectedEditProgram;

            do
            {
                EditMenu();
                //Current selected command.
                selectedEditProgram = Console.ReadLine();
                HandleEditInput(selectedEditProgram);

            } while (endOfEdit);
        }
        //This method is a main logic for edit employee.
        private static void HandleEditInput(string selectedEditComand)
        {
            switch (selectedEditComand)
            {
                case "1": EditEmployeeProject(); break;
                case "2": EditEmployeeSalary(); break;
                case "3": EditEmployeePosition(); break;
                case "4": EndEditOptions(); break;
                default: Console.Write("Please, select from the available options."); break;
            }
        }
        //Edit employee job position.
        private static void EditEmployeePosition()
        {
            Console.Clear();
            //Print all employee.
            HumanResources.PrintAllEmployee();
            //Pick employeeId.
            Console.Write("Please select employee ID: ");
            int employeeIDForEditPosition = int.Parse(Console.ReadLine());
            // Change position.
            var listEmployee = HumanResources.GetEmployees();
            foreach (var employee in listEmployee)
            {
                if (employee.EmployeeId == employeeIDForEditPosition)
                {
                    Console.Write("Please, select job position: ");
                    employee.PositionAtWork = Console.ReadLine();
                }
            }
        }
        //Edit employee salary.
        private static void EditEmployeeSalary()
        {
            Console.Clear();
            //Print all employee.
            HumanResources.PrintAllEmployee();
            //Pick employeeId.
            Console.Write("Please select employee ID: ");
            int employeeIDForEditSalary = int.Parse(Console.ReadLine());
            // Set salary.
            var listEmployee = HumanResources.GetEmployees();
            foreach (var employee in listEmployee)
            {
                if (employee.EmployeeId == employeeIDForEditSalary)
                {
                    Console.Write("Please, write salary in dollars: ");
                    employee.Salary = double.Parse(Console.ReadLine());
                }
            }
        }
        // Assign project 
        private static void EditEmployeeProject()
        {
            Console.Clear();
            //Print all projects
            ProjectManagement.PrintAllProjects();
            //Print all employee
            HumanResources.PrintAllEmployee();
            Console.WriteLine("Assign to project: ");
            //Pick employeeId
            Console.Write("Please select employee ID:");
            int employeeIDForEditProject = int.Parse(Console.ReadLine());
            //Pick project ID
            Console.Write("Please select project ID: ");
            int selectProjectId = int.Parse(Console.ReadLine());
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
        // End edit menu.
        private static void EndEditOptions()
        {
            endOfEdit = false;
            Console.WriteLine("The end of change!");
        }
        //Print edit menu.
        public static void EditMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, select from the following options:");
            Console.WriteLine("1. Edit employee project.");
            Console.WriteLine("2. Edit employee salary.");
            Console.WriteLine("3. Edit employee job position.");
            Console.WriteLine("4. To end changes.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The program expects your input: ");
        }
    }
}
