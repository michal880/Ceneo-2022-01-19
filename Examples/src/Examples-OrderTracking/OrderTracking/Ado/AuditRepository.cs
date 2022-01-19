using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace OrderTracking.Ado
{
  public class AuditRepository : IAuditRepository
  {
    private readonly string _connectionString;

    public AuditRepository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public IEnumerable<AuditData> GetAudit(int id)
    {
      using (SqlConnection connection = SqlConnectionFactory.Create(_connectionString))
      {
        connection.Open();
        return connection.Query<AuditData>("select data, orderId from audit.DataTable where id = @id", new { id });        
      }
    }
  }
}