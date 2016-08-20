namespace HumanResourcesSystem.HumanResourcesOptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HumanResourcesSystem.ProjectInfo;

    class SearchDirectsSuperior
    {
         // Method which print immediate superior of two employees.
        public static void ImmediateSuperior()
        {
            Console.Clear();
            var allEmployeesInCompany = HumanResources.GetEmployees();
            if (allEmployeesInCompany.Count < 1)
            {
                Console.WriteLine("No such employee!");
                StartUp.PrintCommand();
                Console.ReadKey();
                StartUp.PrintMainMenu();
            }
            if (allEmployeesInCompany.Count == 1)
            {
                Console.WriteLine("Have only one employee!");
                StartUp.PrintCommand();
                Console.ReadKey();
                StartUp.PrintMainMenu();
            }
            HumanResources.PrintAllEmployee();
            //Pick employees Id.
            Employee currentFirstEmployee = new Employee();
            Employee currentSecondEmployee = new Employee();
            Console.WriteLine("Please select employees ID: ");
            Console.Write("Please enter ID of the first employee: ");
            int firstEmployeeID = int.Parse(Console.ReadLine());
            Console.Write("Please enter ID of the second employee: ");
            int secondEmployeeID = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (var emp in allEmployeesInCompany)
            {
                if (emp.EmployeeId == firstEmployeeID)
                {
                    currentFirstEmployee = emp;
                }
                if (emp.EmployeeId == secondEmployeeID)
                {
                    currentSecondEmployee = emp;
                }
            }
            CheckSuperiorOfEmployees(currentFirstEmployee, currentSecondEmployee);
        }

        // Method that checks whether employees are working on the same project or not.
        private static void CheckSuperiorOfEmployees(Employee currentFirstEmployee, Employee currentSecondEmployee)
        {
            int convertedPositionFirstEmployee = ConvertPositionAtWork(currentFirstEmployee.PositionAtWork.ToLower());
            int convertedPositionSecondEmployee = ConvertPositionAtWork(currentSecondEmployee.PositionAtWork.ToLower());
            // If work on the same project.
            if (currentFirstEmployee.Project == currentSecondEmployee.Project)
            {
                EmployeeWorkOnSameProject(currentFirstEmployee, convertedPositionFirstEmployee, convertedPositionSecondEmployee);
            }
            // If work on the different projects.
            if (currentFirstEmployee.Project != currentSecondEmployee.Project)
            {
                EmployeeWorkOnDifferentProjects(currentFirstEmployee, currentSecondEmployee, convertedPositionFirstEmployee, convertedPositionSecondEmployee);
            }
        }

        //This method print direct superior if employees works on different projects.
        private static void EmployeeWorkOnDifferentProjects(Employee currentFirstEmployee, Employee currentSecondEmployee, int convertedPositionFirstEmp, int convertedPositionSecondEmp)
        {
            int firstEmployeeProject = currentFirstEmployee.Project;
            int secondEmployeeProject = currentSecondEmployee.Project;
            var allProjects = ProjectManagement.GetProjects();
            string firstEmpProjectDeliveryDirector = null;
            string secondEmpProjectDeliveryDirector = null;

            // If both employees is not a Delivery director.
            if (convertedPositionFirstEmp < 7 && convertedPositionSecondEmp < 7)
            {
                foreach (var proj in allProjects)
                {
                    if (firstEmployeeProject == proj.ProjectId)
                    {
                        firstEmpProjectDeliveryDirector = proj.DeliveryDirectorName;
                    }
                    if (secondEmployeeProject == proj.ProjectId)
                    {
                        secondEmpProjectDeliveryDirector = proj.DeliveryDirectorName;
                    }
                }
                // If both DD is same, Print superior is Delivery director.
                if (firstEmpProjectDeliveryDirector == secondEmpProjectDeliveryDirector)
                {
                    Console.WriteLine("Their superior is Delivery director with name {0}", firstEmpProjectDeliveryDirector);
                }
                // If both DD is different Print superior is CEO.
                else
                {
                    Console.WriteLine("Their superior is CEO with name Richard Brown");
                }
            }
            // If one of the two employees is Delivery director.
            if (convertedPositionFirstEmp == 7 || convertedPositionSecondEmp == 7)
            {
                //Print superior is CEO.
                Console.WriteLine("Their superior is CEO with name Richard Brown");
            }
        }

        //This method print direct superior if employees works on same project.
        private static void EmployeeWorkOnSameProject(Employee currentFirstEmployee, int convertedPositionFirstEmp, int convertedPositionSecondEmp)
        {
            int workingProjectIdOfEmployees = currentFirstEmployee.Project;
            int higherEmployeePosition = 0;
            //If both employee is between trainee and senior.
            if (convertedPositionFirstEmp == 4 && convertedPositionSecondEmp == 4)
            {
                var listEmployee = HumanResources.GetEmployees();
                foreach (var emp in listEmployee)
                {
                    if (emp.Project == workingProjectIdOfEmployees)
                    {
                        if (emp.PositionAtWork == "team leader")
                        {
                            Console.WriteLine("Their superior is Team lead with name {0}", emp.FirstName + " " + emp.LastName);
                        }
                    }
                }
            }
            // If employee position is different or same.
            else 
            {
                if (convertedPositionFirstEmp > convertedPositionSecondEmp)
                {
                    higherEmployeePosition = convertedPositionFirstEmp + 1;
                    PrintSuperior(higherEmployeePosition, workingProjectIdOfEmployees);
                }
                if (convertedPositionSecondEmp >= convertedPositionFirstEmp)
                {
                    higherEmployeePosition = convertedPositionSecondEmp + 1;
                    PrintSuperior(higherEmployeePosition, workingProjectIdOfEmployees);
                }
            }
        }

        // This method print superior of two employees.
        private static void PrintSuperior(int higherPositionOfEmployee, int workingProjectId)
        {
            if (higherPositionOfEmployee == 8)
            {
                Console.WriteLine("Their superior is CEO with name Richard Brown");
            }
            else
            {
                var listEmployee = HumanResources.GetEmployees();
                string positionOfEmployee = null;
                if (higherPositionOfEmployee == 6)
                {
                    positionOfEmployee = "project manager";
                }
                if (higherPositionOfEmployee == 7)
	            {
                    positionOfEmployee = "delivery director";
	            }
                foreach (var emp in listEmployee)
                {
                    if (emp.Project == workingProjectId)
                    {
                        if (emp.PositionAtWork == positionOfEmployee)
                        {
                            Console.WriteLine("Their superior is {0} with name {1}", positionOfEmployee, emp.FirstName + " " + emp.LastName);
                        }
                    }
                }
            }
        }

        // This method converted employye position in number.
        private static int ConvertPositionAtWork(string positionOfEmployee)
        {
            int empoyeePositionNumber = 0;
            switch (positionOfEmployee)
            {
                case "trainee": empoyeePositionNumber = 4; break;
                case "junior":empoyeePositionNumber = 4; break;
                case "intermediate":empoyeePositionNumber = 4; break;
                case "senior":empoyeePositionNumber = 4; break;
                case "team leader":empoyeePositionNumber = 5; break;
                case "project manager":empoyeePositionNumber = 6; break;
                case "delivery director":empoyeePositionNumber = 7; break;
            }
            return empoyeePositionNumber;
        }
    }
}
