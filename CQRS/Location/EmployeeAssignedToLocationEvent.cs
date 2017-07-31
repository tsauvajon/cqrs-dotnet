using System;

namespace CQRS.Location
{
    /// <summary>
    /// Event dispatched when and <see cref="Employee.Employee"/> is added to a <see cref="Location"/>
    /// </summary>
    public class EmployeeAssignedToLocationEvent : BaseEvent
    {
        public readonly int NewLocationID;
        public readonly int EmployeeID;

        public EmployeeAssignedToLocationEvent(Guid id, int newLocationID, int employeeID)
        {
            Id = id;
            NewLocationID = newLocationID;
            EmployeeID = employeeID;
        }
    }
}
