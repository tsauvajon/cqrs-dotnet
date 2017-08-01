using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Location
{
    /// <summary>
    /// Read model for a Location
    /// </summary>
    public class LocationRM
    {
        /// <summary>
        /// Location ID
        /// </summary>
        public int LocationID { get; set; }

        /// <summary>
        /// Street address
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Postal code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Collection of Employees' ID
        /// </summary>
        public List<int> Employees { get; set; }

        /// <summary>
        /// Aggregate ID
        /// </summary>
        public Guid AggregateID { get; set; }

        public LocationRM()
        {
            Employees = new List<int>();
        }
    }
}
