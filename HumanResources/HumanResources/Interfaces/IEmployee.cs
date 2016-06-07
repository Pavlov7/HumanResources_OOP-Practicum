using System;

namespace HumanResources.Interfaces
{
    public interface IEmployee
    {
        string FullName { get; }
        string PersonalNumber { get; }
        string Address { get; }
        DateTime DateEmployed { get; }
        string Manager { get; }
        string Position { get; }

        void ChangeField(string field, string value);
        bool CheckProject(string project);
    }
}
