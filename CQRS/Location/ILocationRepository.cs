using CQRS.CQRSCode;
using CQRS.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Location
{
    /// <summary>
    /// Repository Interface for <see cref="LocationRM"/>
    /// </summary>
    public interface ILocationRepository : IBaseRepository<LocationRM>
    {
        /// <summary>
        /// Get every <see cref="LocationRM"/> of this repo
        /// </summary>
        /// <returns>Collection of locations</returns>
        IEnumerable<LocationRM> GetAll();

        /// <summary>
        /// Get every <see cref="EmployeeRM"/> for a location
        /// </summary>
        /// <param name="locationID">ID of the location</param>
        /// <returns>Collection of employees</returns>
        IEnumerable<EmployeeRM> GetEmployees(int locationID);

        /// <summary>
        /// Checks whether 
        /// </summary>
        /// <param name="locationID">ID of the location</param>
        /// <param name="employeeID">ID of the emloyee</param>
        /// <returns>True if the location contains the employee, false either</returns>
        bool HasEmployee(int locationID, int employeeID);
    }
}
