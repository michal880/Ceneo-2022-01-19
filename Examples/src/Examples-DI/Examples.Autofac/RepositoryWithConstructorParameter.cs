namespace ExamplesAutoFac
{
  public class RepositoryWithConstructorParameter
  {
    public string ConnectionString { get; }

    public RepositoryWithConstructorParameter(string connectionString)
    {
      ConnectionString = connectionString;
    }
  }
}