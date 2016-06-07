using System;
using HumanResources.Interfaces;

namespace HumanResources.Employees
{
    public class SeniorDeveloper : JuniorDeveloper, ITester
    {
        private string projectTesting;
        private string operatingSystem;

        public SeniorDeveloper() : base()
        {
            this.ProjectTesting = "No project";
            this.OpertaingSystem = "No OS";
        }

        public SeniorDeveloper(string name, string number, string address, DateTime date, string manager, string projectDeveloping, string projectTesting,  string os) : base(name, number, address, date, manager, projectDeveloping)
        {
            this.Position = "Senior Developer";
            this.ProjectTesting = projectTesting;
            this.OpertaingSystem = os;
        }

        public string ProjectTesting
        {
            get { return this.projectTesting; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Project testing cannot be empty");
                }

                this.projectTesting = value;
            }
        }

        public string OpertaingSystem
        {
            get { return this.operatingSystem; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Operating system cannot be empty");
                }

                this.operatingSystem = value;
            }
        }

        public override void ChangeField(string field, string value)
        {
            base.ChangeField(field, value);
            switch (field)
            {
                case "project testing":
                    this.ProjectTesting = value;
                    break;
                case "os":
                    this.OpertaingSystem = value;
                    break;
                default:
                    throw new ArgumentException("No such field");
            }
        }

        public override bool CheckProject(string project)
        {
            if (this.projectTesting == project)
            {
                return true;
            }
            else if (this.ProjectDeveloping == project)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string baseInfo = base.ToString();
            string newInfo = string.Format("Project Testing: {0}\nOperating System: {1}\n", this.projectTesting, this.operatingSystem);
            return baseInfo + newInfo;
        }
    }
}
