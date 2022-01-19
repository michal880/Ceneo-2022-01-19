using System;

namespace CQRS.Domain.Base
{
  public interface IRepository<T> where T : AggregateRoot, new()
  {
    void Save(T aggregate, int? expectedVersion);
    T GetById(Guid id);
  }
}