using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AspMvcSec.Models;
using Dapper;

namespace AspMvcSec.DataAccess
{
  public class UserRepository : IUserRepository
  {
    private IDbConnection _connection;

    public UserRepository()
    {
      _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }
    public IEnumerable<UserSummary> GetAll()
    {
      return _connection.Query<UserSummary>("select id, login, name from [User]");      
    }

    public void Add(User user)
    {
      _connection.Execute("Insert into [User](login, name, description,email, password)values(@login,@name,@description,@email, 'sa')", user);
    }

    public void Delete(int id)
    {
      _connection.Execute("Delete from [User] where id = @id",new { id });
    }

    public bool Login(string login, string password)
    {
      var result = _connection.Query<string>("select top 1 password from [User] where login = @login", new { login }).FirstOrDefault();
      if (result == null || result != password)
      {
        return false;
      }
      return true;
    }
  }
}