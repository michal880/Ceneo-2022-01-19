namespace BuilderDesignPattern
{
  public interface ISqlBuilder
  {
    void SetTableName(string tableName);

    void AddColumn(string columnName);

    void SetPrimaryKey(string keyName);

    string GetScript();
  }
}