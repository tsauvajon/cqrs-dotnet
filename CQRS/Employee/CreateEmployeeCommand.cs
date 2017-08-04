using CQRS.CQRSCode;
using System;

namespace CQRS.Employee
{
    /// <summary>
    /// Command for creating an <see cref="Employee"/>
    /// </summary>
    public class CreateEmployeeCommand : BaseCommand
    {
        public readonly int EmployeeID;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly DateTime DateOfBirth;
        public readonly string JobTitle;

        public CreateEmployeeCommand(Guid id, int employeeID, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            Id = id;
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JobTitle = jobTitle;
        }
    }
}
