using System.Collections.Generic;
using AspMvcSec.Models;

namespace AspMvcSec.DataAccess
{
  public interface ICommentsRepository
  {
    IEnumerable<Comment> GetAll();
    void Add(Comment comment);
  }
}