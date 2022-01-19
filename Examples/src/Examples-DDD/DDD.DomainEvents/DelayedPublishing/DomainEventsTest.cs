using System.Linq;
using Xunit;

namespace DDD.DomainEvents.DelayedPublishing
{
  public class DomainEventsTest
  {
    [Fact]
    public void Accept_should_generate_DocumentAcceptedEvent()
    {
      Document d = new Document();
      d.Accept();

      //_repository.Save(d);
      var events = (d as IUnpublishedEventsAccesor).GetUnpublishedEvents();
      // publish events

      Assert.True(events.Count() == 1);
      Assert.True(events.First().GetType() == typeof(DocumentAccepted));
    }
  }
}