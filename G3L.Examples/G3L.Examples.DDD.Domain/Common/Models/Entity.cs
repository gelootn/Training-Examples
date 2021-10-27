using System.Collections;
using System.Collections.Generic;
using System.Linq;
using G3L.Examples.DDD.Domain.Common.Interfaces;

namespace G3L.Examples.DDD.Domain.Common.Models
{
    public class Entity<TId> : IEntity where TId: struct
    {
        private readonly ICollection<IDomainEvent> _events;

        protected Entity() => _events = new List<IDomainEvent>();

        public TId Id { get; private set; } = default;
        public IReadOnlyCollection<IDomainEvent> Events => _events.ToList().AsReadOnly();

        public void ClearEvents() 
            => _events.Clear();

        protected void RaiseEvent(IDomainEvent domainEvent) 
            => _events.Add(domainEvent);
        
    }
}