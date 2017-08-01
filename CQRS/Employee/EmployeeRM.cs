using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Employee
{
    /// <summary>
    /// Read model for an Employee
    /// </summary>
    public class EmployeeRM
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int EmployeeID { get; set; }

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
        /// Job title
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// ID of the location
        /// </summary>
        public int LocationID { get; set; }

        /// <summary>
        /// Aggregate ID
        /// </summary>
        public Guid AggregateID { get; set; }
    }
}
