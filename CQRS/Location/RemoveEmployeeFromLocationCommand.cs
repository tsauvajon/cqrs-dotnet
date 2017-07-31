using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Location
{
    /// <summary>
    /// Command to remove an <see cref="Employee.Employee" /> from a <see cref="Location"/> />
    /// </summary>
    public class RemoveEmployeeFromLocationCommand : BaseCommand
    {
        public readonly int LocationID;
        public readonly int EmployeeID;

        public RemoveEmployeeFromLocationCommand(Guid id, int locationID, int employeeID)
        {
            Id = id;
            EmployeeID = employeeID;
            LocationID = locationID;
        }
    }
}
