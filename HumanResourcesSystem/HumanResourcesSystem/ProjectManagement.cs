﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesSystem
{
    public static class ProjectManagement
    {
        //List of projects.
        private static List<Project> projects = new List<Project>
        {
            new Project {ProjectId = 1, ProjectName = "Secret Project1", AssignedEmployees = new List<IEmployee>() },
            new Project {ProjectId = 2, ProjectName = "Secret Project2", AssignedEmployees = new List<IEmployee>() },
            new Project {ProjectId = 3, ProjectName = "Secret Project3", AssignedEmployees = new List<IEmployee>() }
        };
        //Method which return all projects
        public static List<Project> GetProjects()
        {
            return projects;
        }
        // with this method add emlpoyee into project.
        public static void AssignEmployee(int projectId, IEmployee employee)
        {
            var project = projects.FirstOrDefault(p => p.ProjectId == projectId);
            project.AssignedEmployees.Add(employee);
        }
        //Print all projects.
        public static void PrintAllProjects()
        {
            var projects = ProjectManagement.GetProjects();
            Console.WriteLine("******************************************");
            Console.WriteLine("List of all projects:");
            foreach (var proj in projects)
            {
                Console.WriteLine("ProjectID: {0} - Project name: {1}", proj.ProjectId, proj.ProjectName);
            }
        }
    }
}
