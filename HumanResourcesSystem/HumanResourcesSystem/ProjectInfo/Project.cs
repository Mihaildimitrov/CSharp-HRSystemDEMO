namespace HumanResourcesSystem.ProjectInfo
{
    using System;
    using System.Collections.Generic;

    public class Project
    {
        private string deliveryDirectorName;

        //all prop for any project.
        public string Ceo { get; set; }

        public string DeliveryDirectorName
        {
            get { return this.deliveryDirectorName; }
            set { this.deliveryDirectorName = value; }
        }
        
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public List<Employee> AssignedEmployees { get; set; }
    }
}
