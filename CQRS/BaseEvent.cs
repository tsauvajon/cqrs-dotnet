using CQRSlite.Events;
using System;

namespace CQRS
{
    /// <summary>
    /// Base for an event
    /// </summary>
    public class BaseEvent : IEvent
    {
        /// <summary>
        /// The ID of the aggregate being affected by this event
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Version of the Aggregate which results from this event
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// The UTC timestamp when this event happened
        /// </summary>
        public DateTimeOffset TimeStamp { get; set; }
    }
}
