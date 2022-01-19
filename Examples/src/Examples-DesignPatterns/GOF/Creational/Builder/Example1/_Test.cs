using NUnit.Framework;

namespace GOF.Creational.Builder.Example1
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Test1()
    {
      ISqlBuilder builder = new SqlTableScriptBuilder();

      builder
        .SetTableName("Consumers")
        .AddColumn("Id")
        .AddColumn("Name")
        .AddColumn("Address")
        .SetPrimaryKey("Id");

      string expectedResult = @"CREATE TABLE Consumers
(
Id nvarchar(256) NOT NULL PRIMARY KEY,
Name nvarchar(256) NOT NULL,
Address nvarchar(256) NOT NULL,
)";

      Assert.AreEqual(expectedResult, builder.GetScript());
    }
  }
}