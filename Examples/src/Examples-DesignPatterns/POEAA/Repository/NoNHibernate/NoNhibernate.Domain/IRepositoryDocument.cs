using System;

namespace NoNHibernate
{
  internal interface IRepositoryDocument
  {
    Guid Id { get; }
    string Title { get; }
  }
}