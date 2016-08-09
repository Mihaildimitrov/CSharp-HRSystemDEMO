namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Employee
    {
        // Fields for employee
        private string firstName;
        private string lastName;
        private string positionAtWork;
        private int project;
        private double salary = 0;
        private int employeeId;

        // Property for Firstname
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        // Property for Lastname
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        // Property for selecting job position
        public string PositionAtWork
        {
            get { return this.positionAtWork; }
            set { this.positionAtWork = value; }
        }

        // v project
        public int Project
        {
            get { return this.project; }
            set { this.project = value; }
        }

        // Property for selecting salary
        public double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public int EmployeeId
        {
            get { return this.employeeId; }
            set { this.employeeId = value; }
        }
    }
}
