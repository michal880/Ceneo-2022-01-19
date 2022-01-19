using Xunit;
using System;
using System.Linq;

namespace DDD.DomainEvents.EventSourcing
{
  
  public class DomainEventsTest
  {
    [Fact]
    public void Accept_should_generate_DocumentAcceptedEvent()
    {
      Document3 d = new Document3(12);
      d.Accept();

      var events = (d as IHaveEvents).GetEvents();

      Assert.True(events.Count() == 2);
      Assert.True(events.First().GetType() == typeof(DocumentCreated));
      Assert.True(events.ToList()[1].GetType() == typeof(DocumentAccepted));

      Document3 d2 = new Document3(events);

      Assert.True(d.SameAs(d2));
    }
  }
}