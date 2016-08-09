﻿namespace HumanResourcesSystem.ProjectInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HumanResourcesSystem;

    public class Project
    {
        //all prop for any project.
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public List<Employee> AssignedEmployees { get; set; }
    }
}