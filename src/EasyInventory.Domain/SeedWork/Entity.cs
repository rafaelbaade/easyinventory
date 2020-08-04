using MediatR;
using System;
using System.Collections.Generic;

namespace EasyInventory.Domain.SeedWork
{
    /// <summary>
    /// Object that is not defined by its attributes, but rather by a thread of continuity and its identity
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Domain events related to the entity
        /// </summary>
        private readonly List<INotification> _domainEvents = new List<INotification>();

        /// <summary>
        /// Domain events related to the entity
        /// </summary>
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        /// <summary>
        /// Entity identifier
        /// </summary>
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Add an domain event to the events list
        /// </summary>
        /// <param name="eventItem"></param>
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// Removes all events from the events list
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        /// <summary>
        /// Removes an event form the event list
        /// </summary>
        /// <param name="eventItem">Event to be removed</param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}