using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Domain;
using CQRS.Domain.Base;
using CQRS.Domain.InventoryItem;

namespace CQRS.Infrastructure
{
  public class EventStore : IEventStore
  {
    private struct EventDescriptor
    {
      public readonly Event EventData;
      private readonly Guid Id;
      public readonly int Version;

      public EventDescriptor(Guid id, Event eventData, int version)
      {
        EventData = eventData;
        Version = version;
        Id = id;
      }
    } 

    private static readonly Dictionary<Guid, List<EventDescriptor>> _current = Init();

    private static Dictionary<Guid, List<EventDescriptor>> Init()
    {
      var events = new Dictionary<Guid, List<EventDescriptor>>();
      var eventId = Guid.NewGuid();
      var descriptors = new List<EventDescriptor>();
      descriptors.Add(new EventDescriptor(eventId, new InventoryItemCreated(eventId, "Test1"), 1));
      events.Add(eventId, descriptors);
      return events;
    }

    public void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int? expectedVersion)
    {
      List<EventDescriptor> eventDescriptors;
      if (!_current.TryGetValue(aggregateId, out eventDescriptors))
      {
        eventDescriptors = new List<EventDescriptor>();
        _current.Add(aggregateId, eventDescriptors);
      }
      else if (expectedVersion != null &&
          eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion)
      {
        throw new ConcurrencyException();
      }

      var i = eventDescriptors.Count == 0 ? -1 :
          eventDescriptors[eventDescriptors.Count - 1].Version;
      foreach (var @event in events)
      {
        i++;
        @event.Version = i;
        eventDescriptors.Add(new EventDescriptor(aggregateId, @event, i));        
      }
    }

    public List<Event> GetEventsForAggregate(Guid aggregateId)
    {
      List<EventDescriptor> eventDescriptors;
      if (!_current.TryGetValue(aggregateId, out eventDescriptors))
      {
        throw new AggregateNotFoundException();
      }
      return eventDescriptors.Select(desc => desc.EventData).ToList();
    }

    public IEnumerable<Event> GetAll()
    {
      return _current.SelectMany(f => f.Value.Select(d=>d.EventData));
    }
  }
}