using Xunit;
using System.Linq;

namespace DDD.DomainEvents.InstantPublishing
{
  
  public class DomainEventsTest
  {
    [Fact]
    public void Accept_should_generate_DocumentAcceptedEvent()
    {
      FakeEventPublisher domainEventPublisher = new FakeEventPublisher();
      Document2 d = new Document2();
      DependencyInjector.InjectDependency(d, domainEventPublisher);

      d.Accept();

      var events = domainEventPublisher.UnpublishedEvents;

      Assert.True(events.Count() == 1);
      Assert.True(events.First().GetType() == typeof(DocumentAccepted));
    }
  }
}