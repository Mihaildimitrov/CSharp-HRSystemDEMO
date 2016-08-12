namespace HumanResourcesSystem.ProjectInfo
{
    using System;
    using System.Collections.Generic;
    using HumanResourcesSystem;

    public static class ProjectManagement
    {
        //List of projects.
        private static List<Project> projects = new List<Project>
        {
            new Project {ProjectId = 1, ProjectName = "Secret Project-1", DeliveryDirectorName = null, Ceo = "Richard Brown", AssignedEmployees = new List<Employee>() },
            new Project {ProjectId = 2, ProjectName = "Secret Project-2", DeliveryDirectorName = null, Ceo = "Richard Brown", AssignedEmployees = new List<Employee>() },
            new Project {ProjectId = 3, ProjectName = "Secret Project-3", DeliveryDirectorName = null, Ceo = "Richard Brown", AssignedEmployees = new List<Employee>() },
            new Project {ProjectId = 4, ProjectName = "Secret Project-4", DeliveryDirectorName = null, Ceo = "Richard Brown", AssignedEmployees = new List<Employee>() }
        };
        //Method which return all projects
        public static List<Project> GetProjects()
        {
            return projects;
        }
        // with this method add emlpoyee into project, and set Delivery director name.
        public static void AssignEmployee(int projectId, Employee employee)
        {
            foreach (var proj in projects)
            {
                if (proj.ProjectId == projectId)
                {
                    if (employee.PositionAtWork == "Delivery director")
                    {
                        if (proj.DeliveryDirectorName == null)
                        {
                            proj.AssignedEmployees.Add(employee);
                            // set name it Delivery Director
                            proj.DeliveryDirectorName = employee.FirstName + " " + employee.LastName;
                        }
                        if (proj.DeliveryDirectorName != null)
                        {
                            Console.WriteLine("In this project already have a Delivery director!");
                        }
                    }
                    else
                    {
                        proj.AssignedEmployees.Add(employee);
                    }
                }
            }
        }
        //Print all projects.
        public static void PrintAllProjects()
        {
            var projects = ProjectManagement.GetProjects();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*******************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("List of all projects:");
            foreach (var proj in projects)
            {
                Console.WriteLine("ProjectID: {0} - Project name: {1} - Delivery director: {2} - CEO: {3}", proj.ProjectId, proj.ProjectName, proj.DeliveryDirectorName, proj.Ceo);
            }
        }
    }
}
