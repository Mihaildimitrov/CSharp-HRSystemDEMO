namespace HumanResourcesSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class IEmployee
    {
        // All prop for any Employee.
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PositionAtWork { get; set; }

        public int Project { get; set; }

        public double Salary { get; set; }

        public int EmployeeId { get; set; }
    }
}
