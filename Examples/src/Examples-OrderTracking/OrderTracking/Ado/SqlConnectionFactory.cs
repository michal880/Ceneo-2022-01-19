using System.Data;
using System.Data.SqlClient;

namespace OrderTracking.Ado
{
  public class SqlConnectionFactory
  {
    public static SqlConnection Create(string connectionString)
    {
      var connection = new SqlConnection(connectionString);
      connection.StateChange += Connection_StateChange;
      return connection;
    }

    private static void Connection_StateChange(object sender, StateChangeEventArgs e)
    {
      if (e.OriginalState == ConnectionState.Closed && e.CurrentState == ConnectionState.Open)
      {
        var connection = sender as SqlConnection;
        var cmd = connection.CreateCommand();
        cmd.CommandText = "SET CONTEXT_INFO @id";
        cmd.Parameters.AddWithValue("@id", OrderContext.Id);
        cmd.ExecuteNonQuery();
      }
    }    
  }
}