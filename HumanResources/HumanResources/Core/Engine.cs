using System;
using System.Linq;
using HumanResources.Employees;
using HumanResources.Interfaces;

namespace HumanResources
{
    class Engine
    {
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly ICompany company;

        public Engine(IInputReader reader, IOutputWriter writer, ICompany company)
        {
            this.reader = reader;
            this.writer = writer;
            this.company = company;
        }

        public void Run()
        {
            this.writer.WriteLine("Welcome, please enter a command number:");
            this.PrintMenu();

            while (true)
            {
                this.writer.WriteLine("");
                string input = this.reader.ReadLine();
                this.CommandExecutor(input);
            }
        }

        private void CommandExecutor(string command)
        {
            switch (command)
            {
                case "1":
                    this.EnterCompanyInfo();
                    break;
                case "2":
                    this.PrintCompInfo();
                    break;
                case "3":
                    this.CreateEmployee();
                    break;
                case "4":
                    this.PrintEmployee();
                    break;
                case "5":
                    this.FireEmployee();
                    break;
                case "6":
                    this.ChangeEmployeeData();
                    break;
                case "7":
                    this.PrintEmployeesByProject();
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                case "?":
                    this.PrintMenu();
                    break;
                default:
                    this.writer.WriteLine("Unknown command.");
                    break;
            }
        }

        private void PrintMenu()
        {   
            this.writer.WriteLine("\n? Shows this menu.");
            this.writer.WriteLine("1. Add company info.");
            this.writer.WriteLine("2. Print company info.");
            this.writer.WriteLine("3. Add employee.");
            this.writer.WriteLine("4. Find employee.");
            this.writer.WriteLine("5. Fire employee.");
            this.writer.WriteLine("6. Change employee info.");
            this.writer.WriteLine("7. Print employees by project.");
            this.writer.WriteLine("8. Exit.");
        }

        private void EnterCompanyInfo()
        {
            this.writer.Write("Enter company name: ");
            string name = this.reader.ReadLine();
            this.writer.Write("Enter company address: ");
            string address = this.reader.ReadLine();
            this.writer.Write("Enter company CEO: ");
            string ceo = this.reader.ReadLine();

            this.company.Name = name;
            this.company.Address = address;
            this.company.Ceo = ceo;

            this.writer.WriteLine("Company info changed successfully.");
        }

        private void PrintCompInfo()
        {
            this.writer.WriteLine(this.company.ToString());
        }

        private void CreateEmployee()
        {
            this.writer.Write("Enter employee type (Junior Developer, Junior Tester, Senior Developer): ");
            string type = reader.ReadLine().ToLower();
            if (type != "junior developer" &&  type != "junior tester" && type !=  "senior developer")
            {
                this.writer.WriteLine("Invalid type.");
                return;
            }

            this.writer.Write("Enter employee's name: ");
            string name = reader.ReadLine();
            this.writer.Write("Enter employee's personal number: ");
            string number = reader.ReadLine();
            if (this.company.Employees.ContainsKey(number))
            {
                this.writer.WriteLine("Employee with that personal number already works in the company.");
                return;
            }
            this.writer.Write("Enter employee's address: ");
            string address = reader.ReadLine();
            this.writer.Write("Enter employee's manager: ");
            string manager = reader.ReadLine();
            this.writer.Write("Enter date of employment (dd-mm-yyyy): ");
            int[] date = reader.ReadLine().Split('-').Select(int.Parse).ToArray();

            
            if (type == "junior developer")
            {
                this.writer.Write("Enter name of the project the employee's currently developing: ");
                string project = reader.ReadLine();
                JuniorDeveloper junDev = new JuniorDeveloper(name, number, address, new DateTime(date[2], date[1], date[0]), manager, project);
                this.AddEmployee(junDev);
                return;
            }

            if (type == "junior tester")
            {
                this.writer.Write("Enter name of the project the employee's currently testing: ");
                string project = reader.ReadLine();
                this.writer.Write("Enter name of the OS the employee's currently working with: ");
                string os = reader.ReadLine();
                JuniorTester junTest = new JuniorTester(name, number, address, new DateTime(date[2], date[1], date[0]), manager, project, os);
                this.AddEmployee(junTest);
                return;
            }

            if (type == "senior developer")
            {
               this.writer.Write("Enter name of the project the employee's currently developing: ");
               string projectDev = reader.ReadLine();
               this.writer.Write("Enter name of the project the employee's currently testing: ");
               string projectTest = reader.ReadLine();
               this.writer.Write("Enter name of the OS the employee's currently working with: ");
               string os = reader.ReadLine();
               SeniorDeveloper senDev = new SeniorDeveloper(name, number, address, new DateTime(date[2], date[1], date[0]), manager, projectDev, projectTest, os);
               this.AddEmployee(senDev);
               return;
            }
        }

        private void AddEmployee(Employee newEmployee)
        {
            if (!this.company.Employees.ContainsKey(newEmployee.PersonalNumber))
            {
                this.company.Employees.Add(newEmployee.PersonalNumber, newEmployee);
            }
            else
            {
                throw new Exception("Employee already is in the company"); //This code should be unreachable
            }
        }

        private void FireEmployee()
        {
            this.writer.Write("Enter the personal number of the employee, you wish to fire: ");
            string number = reader.ReadLine();
            if (this.company.Employees.ContainsKey(number))
            {
                this.company.Employees.Remove(number);
            }
            else
            {
                this.writer.WriteLine("Employee with that number does not exist.");
            }
        }

        private void PrintEmployee()
        {
            this.writer.Write("Enter the personal number of the employee, whose info you wish to print: ");
            string number = reader.ReadLine();
            if (this.company.Employees.ContainsKey(number))
            {
                string info = this.company.Employees[number].ToString();
                this.writer.WriteLine(info);
            }
            else
            {
                this.writer.WriteLine("Employee with that number does not exist.");
            }
        }

        private void ChangeEmployeeData()
        {
            this.writer.Write("Enter the personal number of the employee, you wish update: ");
            string number = reader.ReadLine();
            if (!this.company.Employees.ContainsKey(number))
            {
                this.writer.WriteLine("Employee with that personal number does not exist");
                return;
            }
            if (this.company.Employees.ContainsKey(number))
            {
                this.writer.Write("Enter the info of the employee, you wish to change: ");
                string toChange = reader.ReadLine().ToLower();

                switch (toChange)
                {
                    case "name":
                        writer.WriteLine("Enter new name: ");
                        string name = reader.ReadLine();
                        this.company.Employees[number].ChangeField("name", name);
                        break;
                    case "address":
                        writer.WriteLine("Enter new address: ");
                        string address = reader.ReadLine();
                        this.company.Employees[number].ChangeField("address", address);
                        break;
                    case "personal number":
                        writer.WriteLine("Enter new personal number: ");
                        string newNumber = reader.ReadLine();
                        this.company.Employees[number].ChangeField("personal number", newNumber);
                        break;
                    case "manager":
                        writer.WriteLine("Enter new managger: ");
                        string manager = reader.ReadLine();
                        this.company.Employees[number].ChangeField("manager", manager);
                        break;
                    case "project developing":
                        writer.WriteLine("Enter new project developing: ");
                        string projectDev = reader.ReadLine();
                        this.company.Employees[number].ChangeField("project developing", projectDev);
                        break;
                    case "project testing":
                        writer.WriteLine("Enter new project testing: ");
                        string projectTest = reader.ReadLine();
                        this.company.Employees[number].ChangeField("project testing", projectTest);
                        break;
                    case "os":
                        writer.WriteLine("Enter new OS: ");
                        string os = reader.ReadLine();
                        this.company.Employees[number].ChangeField("os", os);
                        break;
                }
            }
        }

        private void PrintEmployeesByProject()
        {
            this.writer.Write("Enter project name: ");
            string projName = reader.ReadLine();
            this.writer.WriteLine(string.Format("Employees currently working on project {0}:",projName));
            foreach (Employee employee in this.company.Employees.Values)
            {
                if (employee.CheckProject(projName))
                {
                    this.writer.WriteLine(employee.ToString());
                }
            }
        }
    }
}