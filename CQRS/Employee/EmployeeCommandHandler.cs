using CQRSlite.Domain;

namespace CQRS.Employee
{
    /// <summary>
    /// Handles commands for an <see cref="Employee"/>
    /// </summary>
    public class EmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
    {
        private readonly ISession session;

        public EmployeeCommandHandler(ISession session)
        {
            this.session = session;
        } 

        public void Handle(CreateEmployeeCommand command)
        {
            Employee employee = new Employee(command.Id, command.EmployeeID, command.FirstName, command.LastName, command.DateOfBirth, command.JobTitle);
            session.Add(employee);
            session.Commit();
        }
    }
}
