using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Employee;
using StackExchange.Redis;
using CQRS.CQRSCode;

namespace CQRS.Location
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "location") { }

        private void MergeIntoAllCollection(LocationRM location)
        {
            List<LocationRM> allLocations = new List<LocationRM>();
            
            if (Exists("all"))
            {
                allLocations = Get<List<LocationRM>>("all");
            }

            // If the ?district already exists in the "all" collection, remove that entry

            if (allLocations.Any(l => l.LocationID == location.LocationID))
            {
                allLocations.Remove(allLocations.First(l => l.LocationID == location.LocationID));
            }

            // Add the modified ?district to the "all" collection
            allLocations.Add(location);
            Save("all", allLocations);
        }

        public IEnumerable<LocationRM> GetAll()
        {
            return Get<List<LocationRM>>("all");
        }

        public LocationRM GetByID(int locationID)
        {
            return Get<LocationRM>(locationID);
        }

        public IEnumerable<EmployeeRM> GetEmployees(int locationID)
        {
            return Get<List<EmployeeRM>>(locationID.ToString() + ":employees");
        }

        public List<LocationRM> GetMultiple(List<int> locationIDs)
        {
            return GetMultiple(locationIDs);
        }

        public bool HasEmployee(int locationID, int employeeID)
        {
            // Deserialize the LocationDTO with the key location:{locationID}
            var location = Get<LocationRM>(locationID);

            // If that location has the specified Employee, return true
            return location.Employees.Contains(employeeID);
        }

        public void Save(LocationRM location)
        {
            Save(location.LocationID, location);
            MergeIntoAllCollection(location);
        }
    }
}
