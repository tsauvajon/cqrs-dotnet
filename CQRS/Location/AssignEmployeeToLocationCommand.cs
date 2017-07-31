using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Location
{
    /// <summary>
    /// Command to assign an <see cref="Employee.Employee" /> to a <see cref="Location"/> />
    /// </summary>
    public class AssignEmployeeToLocationCommand : BaseCommand
    {
        public readonly int LocationID;
        public readonly int EmployeeID;

        public AssignEmployeeToLocationCommand(Guid id, int locationID, int employeeID)
        {
            Id = id;
            LocationID = locationID;
            EmployeeID = employeeID;
        }
    }
}
