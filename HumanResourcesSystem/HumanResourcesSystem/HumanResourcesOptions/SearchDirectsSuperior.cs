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
         // method which print immediate superior of two employees.
        public static void ImmediateSuperior()
        {
            Console.Clear();
            var allEmp = HumanResources.GetEmployees();
            if (allEmp.Count < 1)
            {
                Console.WriteLine("No such employee!");
                StartUp.PrintCommand();
                Console.ReadKey();
                StartUp.PrintMainMenu();
            }
            if (allEmp.Count == 1)
            {
                Console.WriteLine("Have only one employee!");
                StartUp.PrintCommand();
                Console.ReadKey();
                StartUp.PrintMainMenu();
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

        // method that checks whether employees are working on the same project or not
        private static void CheckSuperior(Employee currentFirstEmployee, Employee currentSecondEmployee)
        {
            int convertedPositionFirstEmp = ConvertPositionAtWork(currentFirstEmployee.PositionAtWork.ToLower());
            int convertedPositionSecondEmp = ConvertPositionAtWork(currentSecondEmployee.PositionAtWork.ToLower());
            // If work on the same project
            if (currentFirstEmployee.Project == currentSecondEmployee.Project)
            {
                EmployeeWorkOnSameProject(currentFirstEmployee, convertedPositionFirstEmp, convertedPositionSecondEmp);
            }
            // If work on the different projects
            if (currentFirstEmployee.Project != currentSecondEmployee.Project)
            {
                EmployeeWorkOnDifferentProjects(currentFirstEmployee, currentSecondEmployee, convertedPositionFirstEmp, convertedPositionSecondEmp);
            }
        }

        //This method print direct superior if employees works on different projects
        private static void EmployeeWorkOnDifferentProjects(Employee currentFirstEmployee, Employee currentSecondEmployee, int convertedPositionFirstEmp, int convertedPositionSecondEmp)
        {
            int firstEmpProj = currentFirstEmployee.Project;
            int secondEmpProj = currentSecondEmployee.Project;
            var allProj = ProjectManagement.GetProjects();
            string firstEmpProjectDeliveryDirector = null;
            string secondEmpProjectDeliveryDirector = null;

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

        //This method print direct superior if employees works on same project
        private static void EmployeeWorkOnSameProject(Employee currentFirstEmployee, int convertedPositionFirstEmp, int convertedPositionSecondEmp)
        {
            int workingProjectId = currentFirstEmployee.Project;
            int higherPosition = 0;
            //If both employee is between trainee and senior
            if (convertedPositionFirstEmp == 4 && convertedPositionSecondEmp == 4)
            {
                var listEmployee = HumanResources.GetEmployees();
                foreach (var emp in listEmployee)
                {
                    if (emp.Project == workingProjectId)
                    {
                        if (emp.PositionAtWork == "team leader")
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
                if (higherPosition == 6)
                {
                    position = "project manager";
                }
                if (higherPosition == 7)
	            {
                    position = "delivery director";
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
            }
            return empPositionNumber;
        }
    }
}
