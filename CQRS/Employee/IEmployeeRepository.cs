using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Employee
{
    /// <summary>
    /// Repository Interface for <see cref="EmployeeRM"/>
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<EmployeeRM>
    {
        /// <summary>
        /// Get every <see cref="EmployeeRM"/> of this repo
        /// </summary>
        /// <returns>Collection of employees</returns>
        IEnumerable<EmployeeRM> GetAll();
    }
}
