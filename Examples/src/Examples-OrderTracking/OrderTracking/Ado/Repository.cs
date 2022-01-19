using System.Data.SqlClient;

namespace OrderTracking.Ado
{
  public class Repository : IRepository
  {
    private readonly string _connectionString;

    public Repository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public void Add(int id, string data)
    {
      using (SqlConnection connection = SqlConnectionFactory.Create(_connectionString))
      {
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd = connection.CreateCommand();
        cmd.Parameters.AddWithValue("@data", data);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.CommandText = "INSERT INTO DataTable(id, Data) VALUES(@id, @data)";
        cmd.ExecuteNonQuery();
      }
    }
  }
}