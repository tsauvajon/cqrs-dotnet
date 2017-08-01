using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS
{
    /// <summary>
    /// Generic Event Handler interface
    /// </summary>
    /// <typeparam name="T"><see cref="IEvent"/> to handle</typeparam>
    public interface IEventHandler<in T> : IHandler<T> where T : IEvent
    {
    }
}
