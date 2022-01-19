namespace FeatureFolders.Implementation.Client.Query
{
  public class ClientType
  {
    public ClientType(int id, string description)
    {
      Id = id;
      Description = description;
    }

    public int Id { get; set; }
    public string Description { get; set; }
  }
}