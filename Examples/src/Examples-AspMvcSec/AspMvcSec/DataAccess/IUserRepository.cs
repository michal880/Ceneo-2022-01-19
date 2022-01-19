using System.Collections.Generic;
using AspMvcSec.Models;

namespace AspMvcSec.DataAccess
{
  public interface IUserRepository
  {
    IEnumerable<UserSummary> GetAll();
    void Add(User user);
    void Delete(int id);
    bool Login(string login, string password);
  }
}