using System.Collections.Generic;

namespace GOF.Creational.Builder.Example1
{
  public class SqlTableScriptBuilder : ISqlBuilder
  {
    private string _tableName;
    private List<string> _columns = new List<string>();
    private string _primaryKey;

    public ISqlBuilder SetTableName(string tableName)
    {
      _tableName = tableName;
      return this;
    }

    public ISqlBuilder AddColumn(string name)
    {
      _columns.Add(name);
      return this;
    }

    public ISqlBuilder SetPrimaryKey(string columnName)
    {
      _primaryKey = columnName;
      return this;
    }

    public string GetScript()
    {
      string result = "CREATE TABLE " + _tableName + "\n(\n";
      foreach (string column in _columns)
      {
        result += column + " nvarchar(256) NOT NULL";
        if (column.ToLower() == _primaryKey.ToLower())
        {
          result += " PRIMARY KEY";
        }
        result += ",\n";
      }
      result += ")";

      return result;
    }
  }

  public interface ISqlBuilder
  {
    ISqlBuilder SetTableName(string tableName);

    ISqlBuilder AddColumn(string columnName);

    ISqlBuilder SetPrimaryKey(string keyName);

    string GetScript();
  }
}