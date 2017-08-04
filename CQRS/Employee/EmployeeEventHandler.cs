using System;
using System.Threading.Tasks;
using AutoMapper;
using CQRSlite.Messages;
using CQRS.CQRSCode;

namespace CQRS.Employee
{
    /// <summary>
    /// Event Handle for Employee events
    /// </summary>
    public class EmployeeEventHandler : IEventHandler<EmployeeCreatedEvent>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepo;

        public EmployeeEventHandler(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.employeeRepo = employeeRepo;
        }

        public void Handle(EmployeeCreatedEvent message)
        {
            EmployeeRM employee = mapper.Map<EmployeeRM>(message);
            employeeRepo.Save(employee);
        }
    }
}
