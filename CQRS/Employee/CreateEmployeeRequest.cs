using System;

namespace CQRS.Employee
{
    /// <summary>
    /// Request for creating an Employee
    /// </summary>
    public class CreateEmployeeRequest
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Title of the job
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Identifier of the Employee's Location
        /// </summary>
        public int LocationID { get; set; }
    }
}
