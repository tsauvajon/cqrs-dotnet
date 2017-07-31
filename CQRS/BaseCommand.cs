using CQRSlite.Commands;
using System;

namespace CQRS
{
    /// <summary>
    /// Base for a command
    /// </summary>
    public class BaseCommand : ICommand
    {
        /// <summary>
        /// The Aggregate ID of the Aggregate Root being changed
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Expected Version which the Aggregate will become
        /// </summary>
        public int ExpectedVersion { get; set; }
    }
}
