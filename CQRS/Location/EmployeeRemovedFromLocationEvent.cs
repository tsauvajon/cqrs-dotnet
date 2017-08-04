using CQRS.CQRSCode;
using System;

namespace CQRS.Location
{
    /// <summary>
    /// Event dispatched when and <see cref="Employee.Employee"/> is removed from a <see cref="Location"/>
    /// </summary>
    public class EmployeeRemovedFromLocationEvent : BaseEvent
    {
        public readonly int OldLocationID;
        public readonly int EmployeeID;

        public EmployeeRemovedFromLocationEvent(Guid id, int oldLocationID, int employeeID)
        {
            Id = id;
            OldLocationID = oldLocationID;
            EmployeeID = employeeID;
        }
    }
}
