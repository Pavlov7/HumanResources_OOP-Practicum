using System;
using HumanResources.Interfaces;

namespace HumanResources.Employees
{
    public class JuniorTester : Employee, ITester
    {
        private string projectTesting;
        private string operatingSystem;

        public JuniorTester() : base()
        {
            this.ProjectTesting = "No project";
            this.OpertaingSystem = "No OS";
        }

        public JuniorTester(string name, string number, string address, DateTime date, string manager, string project, string os) : base(name, number, address, date, manager)
        {
            this.Position = "Junior Tester";
            this.ProjectTesting = project;
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
            if (this.ProjectTesting == project)
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
