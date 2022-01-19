using NoNHibernate;
using System;

namespace NoNhibernate.Infrastructure
{
  public class DocumentRepository : IDocumentRepository
  {
    public void Save(Document document)
    {
      IRepositoryDocument doc = document;
      SaveToDb(doc.Id, doc.Title);
    }

    private void SaveToDb(Guid id, string title)
    {
      // done;
    }
  }
}