using CQRS.CQRSCode;
using CQRSlite.Domain;

namespace CQRS.Location
{
    /// <summary>
    /// Handles commands for a <see cref="Location"/>
    /// </summary>
    public class LocationCommandHandler : ICommandHandler<CreateLocationCommand>,
        ICommandHandler<AssignEmployeeToLocationCommand>,
        ICommandHandler<RemoveEmployeeFromLocationCommand>
    {
        private readonly ISession session;

        public LocationCommandHandler(ISession session)
        {
            this.session = session;
        }

        public async void Handle(CreateLocationCommand command)
        {
            var location = new Location(command.Id, command.LocationID, command.StreetAddress, command.City, command.State, command.PostalCode);
            await session.Add(location);
            await session.Commit();
        }

        public async void Handle(AssignEmployeeToLocationCommand command)
        {
            var location = await session.Get<Location>(command.Id);
            location.AddEmployee(command.EmployeeID);
            await session.Commit();
        }

        public async void Handle(RemoveEmployeeFromLocationCommand command)
        {
            var location = await session.Get<Location>(command.Id);
            location.RemoveEmployee(command.EmployeeID);
            await session.Commit();
        }
    }
}
