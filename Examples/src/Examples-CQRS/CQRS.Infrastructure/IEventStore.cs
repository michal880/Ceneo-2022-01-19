using System;
using System.Collections.Generic;
using CQRS.Domain;
using CQRS.Domain.Base;

namespace CQRS.Infrastructure
{
  public interface IEventStore
  {
    void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int? expectedVersion);
    List<Event> GetEventsForAggregate(Guid aggregateId);
    IEnumerable<Event> GetAll();
  }
}