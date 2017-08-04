using AutoMapper;
using CQRS.CQRSCode;
using CQRS.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Location
{
    /// <summary>
    /// Event handler for locations
    /// </summary>
    public class LocationEventHandler : IEventHandler<LocationCreatedEvent>,
        IEventHandler<EmployeeAssignedToLocationEvent>,
        IEventHandler<EmployeeRemovedFromLocationEvent>
    {
        private readonly IMapper mapper;
        private readonly ILocationRepository locationRepo;
        private readonly IEmployeeRepository employeeRepo;

        public LocationEventHandler(IMapper mapper, ILocationRepository locationRepo, IEmployeeRepository employeeRepo)
        {
            this.mapper = mapper;
            this.locationRepo = locationRepo;
            this.employeeRepo = employeeRepo;
        }

        public void Handle(LocationCreatedEvent message)
        {
            // Create a new LocationDTO object from the LocationCreatedEvent
            LocationRM location = mapper.Map<LocationRM>(message);

            locationRepo.Save(location);
        }

        public void Handle(EmployeeAssignedToLocationEvent message)
        {
            var location = locationRepo.GetByID(message.NewLocationID);
            location.Employees.Add(message.EmployeeID);
            locationRepo.Save(location);

            // Find the employee which was assigned to this location
            var employee = employeeRepo.GetByID(message.EmployeeID);
            employee.LocationID = message.NewLocationID;
            employeeRepo.Save(employee);
        }

        public void Handle(EmployeeRemovedFromLocationEvent message)
        {
            var location = locationRepo.GetByID(message.OldLocationID);
            location.Employees.Remove(message.EmployeeID);
            locationRepo.Save(location);
        }
    }
}
