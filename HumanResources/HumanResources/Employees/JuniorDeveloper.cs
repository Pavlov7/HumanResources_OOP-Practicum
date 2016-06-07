using System;
using HumanResources.Interfaces;

namespace HumanResources.Employees
{
    public class JuniorDeveloper : Employee, IDeveloper
    {
        private string pojectDeveloping;

        public JuniorDeveloper(): base()
        {
            this.ProjectDeveloping = "No project";
        }

        public JuniorDeveloper(string name, string number, string address, DateTime date, string manager, string project) : base(name, number, address, date, manager)
        {
            this.Position = "Junior Developer";
            this.ProjectDeveloping = project;
        }

        public string ProjectDeveloping
        {
            get { return this.pojectDeveloping; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Project cannot be empty.");
                }

                this.pojectDeveloping = value;
            }
        }

        public override void ChangeField(string field, string value)
        {
            base.ChangeField(field, value);
            if (field == "project developing")
            {
                this.ProjectDeveloping = value;
            }
            else
            {
                throw new ArgumentException("No such field");
            }
        }

        public override bool CheckProject(string project)
        {
            if (this.pojectDeveloping == project)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string baseInfo = base.ToString();
            string newInfo = string.Format("Project Developing: {0}\n", this.pojectDeveloping);
            string allInfo = baseInfo + newInfo;
            return allInfo;
        }
    }
}
