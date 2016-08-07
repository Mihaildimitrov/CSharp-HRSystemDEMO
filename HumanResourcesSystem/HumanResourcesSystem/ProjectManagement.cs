using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesSystem
{
    public static class ProjectManagement
    {
        private static List<Project> projects = new List<Project>
        {
            new Project {ProjectId = 1, ProjectName = "Secret Project1", AssignedEmployees = new List<IEmployee>() },
            new Project {ProjectId = 2, ProjectName = "Secret Project2", AssignedEmployees = new List<IEmployee>() },
            new Project {ProjectId = 3, ProjectName = "Secret Project3", AssignedEmployees = new List<IEmployee>() }
        };

        public static List<Project> GetProjects()
        {
            return projects;
        }

        public static void AssignEmployee(int projectId, IEmployee employee)
        {
            var project = projects.FirstOrDefault(p => p.ProjectId == projectId);
            project.AssignedEmployees.Add(employee);
        }

        public static void PrintAllProjects()
        {
            var projects = ProjectManagement.GetProjects();
            foreach (var proj in projects)
            {
                Console.WriteLine("{0} - {1}", proj.ProjectId, proj.ProjectName);
            }
        }
    }
}
