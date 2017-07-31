using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Location
{
    /// <summary>
    ///  Command for creating a <see cref="Location"/>
    /// </summary>
    public class CreateLocationCommand : BaseCommand
    {
        public readonly int LocationID;
        public readonly string StreetAddress;
        public readonly string City;
        public readonly string State;
        public readonly string PostalCode;

        public CreateLocationCommand(Guid id, int locationID, string streetAddress, string city, string state, string postalCode)
        {
            Id = id;
            LocationID = locationID;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
    }
}
