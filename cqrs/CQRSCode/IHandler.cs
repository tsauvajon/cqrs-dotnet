using CQRSlite.Messages;
using System.Threading.Tasks;

namespace CQRS.CQRSCode
{
    /// <summary>
    /// Generic Handler
    /// </summary>
    /// <typeparam name="T"><see cref="IMessage"/> to handle</typeparam>
    public interface IHandler<in T> where T : IMessage
    {
        void Handle(T message);
    }
}
