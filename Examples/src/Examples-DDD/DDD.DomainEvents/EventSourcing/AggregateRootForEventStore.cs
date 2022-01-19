using System;
using System.Collections.Generic;
using System.Reflection;

namespace DDD.DomainEvents.EventSourcing
{
  public class AggregateRootForEventStore : IHaveEvents
  {
    public enum AggregateStatus
    {
      ACTIVE, ARCHIVE
    }

    public class DomainException : Exception
    {
      public DomainException(string msg) : base(msg)
      {
      }
    }

    public int Id { get; protected set; }
    public int Version { get; private set; }

    private AggregateStatus _aggregateStatus = AggregateStatus.ACTIVE;
    private readonly List<IDomainEvent> _uncommitedEvents = new List<IDomainEvent>();

    public AggregateRootForEventStore(int id)
    {
      Id = id;
    }

    protected AggregateRootForEventStore()
    { }

    public void LoadFromHistory(IEnumerable<IDomainEvent> events)
    {
      Version = 0;
      foreach (IDomainEvent domainEvent in events)
      {
        InvokeApply(domainEvent);
      }
    }

    private void InvokeApply(IDomainEvent domainEvent)
    {
      var method = GetType().GetMethod("Apply", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { domainEvent.GetType() }, null);
      if (method == null)
      {
        throw new DomainException("Cannot find method: Apply(" + domainEvent.GetType().Name + ")");
      }

      method.Invoke(this, new object[] { domainEvent });
      Version++;
    }

    public void MarkAsRemoved()
    {
      _aggregateStatus = AggregateStatus.ARCHIVE;
    }

    public bool IsRemoved()
    {
      return _aggregateStatus == AggregateStatus.ARCHIVE;
    }

    protected void ApplyChange<T>(T domainEvent) where T : IDomainEvent
    {
      _uncommitedEvents.Add(domainEvent);
      InvokeApply(domainEvent);
    }

    public IEnumerable<IDomainEvent> GetEvents()
    {
      return _uncommitedEvents;
    }
  }
}