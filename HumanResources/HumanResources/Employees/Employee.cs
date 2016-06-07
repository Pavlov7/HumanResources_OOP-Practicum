using System;
using HumanResources.Interfaces;

namespace HumanResources.Employees
{
    public abstract class Employee : IEmployee
    {   
        private string fullName;
        private string personalNumber;
        private string address;
        private string manager;

        protected Employee()
        {
            this.fullName = "Unnamed";
            this.personalNumber = "0000000000";
            this.address = "No address";
            this.DateEmployed = new DateTime(0000, 00, 00);
            this.manager = "No manager";
            this.Position = "No position";
        }

        protected Employee(string name, string number, string address, DateTime date, string manager)
        {
            this.FullName = name;
            this.PersonalNumber = number;
            this.Address = address;
            this.DateEmployed = date;
            this.Manager = manager;
        }

        public string FullName
        {
            get { return this.fullName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.fullName = value;
            }
        }

        public string PersonalNumber
        {
            get { return this.personalNumber; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("Personal nuumber must be 10 digits long.");
                }

                this.personalNumber = value;
            }
        }

        public string Address
        {
            get { return this.address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address cannot be empty.");
                }

                this.address = value;
            }
        }

        public DateTime DateEmployed { get; set; }

        public string Manager
        {
            get { return this.manager; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manager cannot be empty.");
                }

                this.manager = value;
            }
        }

        public string Position { get; set; }

        public virtual void ChangeField(string field, string value)
        {
            switch (field)
            {
                case "name":
                    this.FullName = value;
                    break;
                case "personal number":
                    this.PersonalNumber = value;
                    break;
                case "address":
                    this.Address = value;
                    break;
                case "manager":
                    this.Manager = value;
                    break;
            }
        }

        public virtual bool CheckProject(string project)
        {
            return false;
        }

        public override string ToString()
        {
            string info =
                string.Format(
                    "Name: {0}\nPosition: {1}\nPersonal Number: {2}\nAddress: {3}\nManager: {4}\nDate Employed: {5}\n",
                    this.fullName, this.Position, this.personalNumber, this.address, this.manager, this.DateEmployed);
            return info;
        }
    }
}
