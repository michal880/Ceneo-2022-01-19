using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNHibernate
{
  public class Document : IRepositoryDocument
  {
    private Guid _id;
    private string _title;

    Guid IRepositoryDocument.Id{get { return _id; }}
    string IRepositoryDocument.Title { get { return _title;  } }
  }
}
