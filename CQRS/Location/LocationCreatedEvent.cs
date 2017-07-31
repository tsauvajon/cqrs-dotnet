using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Location
{
    /// <summary>
    /// Event dispatched after a <see cref="Location"/> is created
    /// </summary>
    public class LocationCreatedEvent : BaseEvent
    {
        public readonly int LocationID;
        public readonly string StreetAddress;
        public readonly string City;
        public readonly string State;
        public readonly string PostalCode;

        public LocationCreatedEvent(Guid id, int locationID, string streetAddress, string city, string state, string postalCode)
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
