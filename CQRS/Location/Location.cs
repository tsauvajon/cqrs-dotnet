using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Location
{
    /// <summary>
    /// Point of Interest
    /// </summary>
    public class Location : AggregateRoot
    {
        private int locationID;
        private string streetAddress;
        private string city;
        private string state;
        private string postalCode;
        private List<int> employees;

        private Location() { }

        public Location(Guid id, int locationID, string streetAddress, string city, string state, string postalCode)
        {
            Id = id;
            this.locationID = locationID;
            this.streetAddress = streetAddress;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;

            ApplyChange(new LocationCreatedEvent(id, locationID, streetAddress, city, state, postalCode));
        }

        public void AddEmployee(int employeeID)
        {
            employees.Add(employeeID);
            ApplyChange(new EmployeeAssignedToLocationEvent(Id, locationID, employeeID));
        }

        public void RemoveEmployee(int employeeID)
        {
            employees.Remove(employeeID);
            ApplyChange(new EmployeeRemovedFromLocationEvent(Id, locationID, employeeID));
        }
    }
}
