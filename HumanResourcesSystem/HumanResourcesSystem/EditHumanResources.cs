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
        public static void EditEmployee()
        {

            string selectedEditProgram;

            do
            {
                EditMenu();
                selectedEditProgram = Console.ReadLine();
                try
                {
                    HandleEditInput(selectedEditProgram);
                }
                catch (Exception)
                {

                    throw;
                }

            } while (endOfEdit);
        }

        private static void HandleEditInput(string selectedEditComand)
        {
            switch (selectedEditComand)
            {
                case "1": EditEmployeeProject(); break;
                case "2": ; break;
                case "3": ; break;
                case "4": EndEditOptions(); break;
                default: Console.Write("Please, select from the available options."); break;
            }
        }

        private static void EditEmployeeProject()
        {
            
            //print all projects
            Console.WriteLine("List of all projects:");
            ProjectManagement.PrintAllProjects();
            //print all employee
            Console.WriteLine("List of all employees");
            HumanResources.PrintAllEmployee();
            Console.WriteLine("Assign to project: ");
            //Pick employeeId
            Console.Write("Please select employee ID:");
            int employeeIDForEditProject = int.Parse(Console.ReadLine());
            //Pick project ID
            Console.Write("Please select project ID: ");
            int selectProjectId = int.Parse(Console.ReadLine());
            // set project!!!!!!!!!!!
            var listEmployee = HumanResources.GetEmployees();
            foreach (var asd in listEmployee)
            {
                if (asd.EmployeeId == employeeIDForEditProject)
                {
                    asd.Project = selectProjectId;
                }
            }
        }

        private static void EndEditOptions()
        {
            endOfEdit = false;
            Console.WriteLine("The end of change!");
        }

        public static void EditMenu()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("Please, select from the following options:");
            Console.WriteLine("1. Edit employee project");
            Console.WriteLine("3. Edit employee salary");
            Console.WriteLine("2. Edit employee job position");
            Console.WriteLine("4. To end changes");
            Console.WriteLine("The program expects your input!");
        }
    }
}
