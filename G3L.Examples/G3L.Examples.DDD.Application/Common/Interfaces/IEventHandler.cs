using System.Threading.Tasks;
using G3L.Examples.DDD.Domain.Common.Interfaces;

namespace G3L.Examples.DDD.Application.Common.Interfaces
{
    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}