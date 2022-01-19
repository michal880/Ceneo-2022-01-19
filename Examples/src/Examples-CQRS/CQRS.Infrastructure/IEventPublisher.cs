using System;
using CQRS.Domain;
using CQRS.Domain.Base;

namespace CQRS.Infrastructure
{
  public interface IEventPublisher
  {
    void Publish<T>(T @event) where T : Event;
    void RegisterHandler<T>(Action<T> handler);
  }
}