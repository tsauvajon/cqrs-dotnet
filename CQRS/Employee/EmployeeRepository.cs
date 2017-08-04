using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using CQRS.CQRSCode;

namespace CQRS.Employee
{
    /// <summary>
    /// Concrete class : <see cref="EmployeeRM"/> repo
    /// </summary>
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "employee") { }

        private void MergeIntoAllCollection(EmployeeRM employee)
        {
            List<EmployeeRM> allEmployees = new List<EmployeeRM>();

            if (Exists("all"))
            {
                allEmployees = Get<List<EmployeeRM>>("all");
            }

            // If the ?district already exists in the "all" collection, remove that entry

            if (allEmployees.Any(e => e.EmployeeID == employee.EmployeeID))
            {
                allEmployees.Remove(allEmployees.First(e => e.EmployeeID == employee.EmployeeID));
            }

            // Add the modified ?district to the "all" collection
            allEmployees.Add(employee);

            Save("all", allEmployees);
        }

        public IEnumerable<EmployeeRM> GetAll()
        {
            return Get<List<EmployeeRM>>("all");
        }

        public EmployeeRM GetByID(int employeeID)
        {
            return Get<EmployeeRM>(employeeID);
        }

        public List<EmployeeRM> GetMultiple(List<int> employeeIDs)
        {
            return GetMultiple<EmployeeRM>(employeeIDs);
        }

        public void Save(EmployeeRM employee)
        {
            Save(employee.EmployeeID, employee);
            MergeIntoAllCollection(employee);
        }
    }
}
