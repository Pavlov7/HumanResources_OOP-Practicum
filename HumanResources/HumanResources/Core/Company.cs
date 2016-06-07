using System;
using System.Collections.Generic;
using HumanResources.Employees;
using HumanResources.Interfaces;

namespace HumanResources
{
    public class Company: ICompany
    {
        private string name;
        private string address;
        private string ceo;
        private Dictionary<string, Employee> employees;

        public Company()
        {
            this.name = "Unnamed";
            this.address = "No address";
            this.ceo = "No CEO";
            this.employees = new Dictionary<string, Employee>();
        }

        public Company(string name, string address, string ceo)
        {
            this.Name = name;
            this.Address = address;
            this.Ceo = ceo;
            this.employees = new Dictionary<string, Employee>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public string Address
        {
            get { return this.address; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Address cannot be empty");
                }

                this.address = value;
            }
        }

        public string Ceo
        {
            get { return this.ceo; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("CEO cannot be empty");
                }

                this.ceo = value;
            }
        }

        public Dictionary<string, Employee> Employees
        {
            get { return this.employees; }
        }

        public override string ToString()
        {
            string info = string.Format("Name: {0}\nAddress: {1}\nCEO: {2}",  this.name, this.address, this.ceo);
            return info;
        }
    }
}
