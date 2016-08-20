namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        // Fields for employee.
        private string firstNameOfEmployee;
        private string lastNameOfEmployee;
        private string employeePositionAtWork;
        private int employeeProject;
        private int employeeId;

        // Property for firstname of the employee.
        public string FirstName
        {
            get { return this.firstNameOfEmployee; }
            set { this.firstNameOfEmployee = value; }
        }

        // Properties for lastname of the employee.
        public string LastName
        {
            get { return this.lastNameOfEmployee; }
            set { this.lastNameOfEmployee = value; }
        }

        // Properties for selecting job position of the employee.
        public string PositionAtWork
        {
            get { return this.employeePositionAtWork; }
            set { this.employeePositionAtWork = value; }
        }

        //Properties for project of the employee.
        public int Project
        {
            get { return this.employeeProject; }
            set { this.employeeProject = value; }
        }
        // Properties for employee ID.
        public int EmployeeId
        {
            get { return this.employeeId; }
            set { this.employeeId = value; }
        }
    }
}
