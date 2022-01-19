using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AspMvcSec.Models;
using Dapper;

namespace AspMvcSec.DataAccess
{
  public class CommentsRepository : ICommentsRepository
  {
    private IDbConnection _connection;

    public CommentsRepository()
    {
      _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }

    public IEnumerable<Comment> GetAll()
    {
      return _connection.Query<Comment>("Select date, who, text from Comment order by date");
    }

    public void Add(Comment comment)
    {
      _connection.Execute("Insert into [Comment](who, date, text)values(@who,@date,@text)", comment);
    }
  }
}