using CQRS.CQRSCode;
using System.Collections.Generic;

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
