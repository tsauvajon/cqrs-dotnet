using CQRSlite.Domain;
using System;

namespace CQRS.Employee
{
    /// <summary>
    /// A restaurant Employee
    /// </summary>
    public class Employee : AggregateRoot
    {
        private int employeeID;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string jobTitle;

        private Employee()
        {

        }

        public Employee(Guid id, int employeeID, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            Id = id;
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.jobTitle = jobTitle;

            ApplyChange(new EmployeeCreatedEvent(id, employeeID, firstName, lastName, dateOfBirth, jobTitle));
        }
    }
}
