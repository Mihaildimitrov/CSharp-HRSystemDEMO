namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        // Fields for employee.
        private string firstName;
        private string lastName;
        private string positionAtWork;
        private int project;
        private int employeeId;

        // Property for Firstname.
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        // Properties for Lastname.
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        // Properties for selecting job position.
        public string PositionAtWork
        {
            get { return this.positionAtWork; }
            set { this.positionAtWork = value; }
        }

        //Properties for project.
        public int Project
        {
            get { return this.project; }
            set { this.project = value; }
        }
        // Properties for employee ID.
        public int EmployeeId
        {
            get { return this.employeeId; }
            set { this.employeeId = value; }
        }
    }
}
