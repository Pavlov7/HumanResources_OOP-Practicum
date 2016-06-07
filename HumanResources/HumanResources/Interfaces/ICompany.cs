using System.Collections.Generic;
using HumanResources.Employees;

namespace HumanResources.Interfaces
{
    public interface ICompany
    {
        string Name { get; set; }
        string Address { get; set; }
        string Ceo { get; set; }
        Dictionary<string, Employee> Employees { get; }
    }
}
