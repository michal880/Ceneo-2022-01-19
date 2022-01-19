using System;
using System.Data.SqlClient;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;

namespace OrderTracking.NHibarnate
{
  public class TestBase
  {
    protected ISessionFactory _sessionFactory;

    //[SetUp]
    public void Setup()
    {
      AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

      Configuration configuration = new Configuration();
      configuration.DataBaseIntegration(f => f.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote);

      var mapper = new ModelMapper();

      var allEntities = GetType().Assembly.GetTypes().ToList();

      var mappings = allEntities.Where(t => IsSubclassOfRawGeneric(typeof(ClassMapping<>), t));
      mapper.AddMappings(mappings);
      var mapping = mapper.CompileMappingFor(allEntities);
      configuration.AddDeserializedMapping(mapping, "NHSchema");

      configuration.Configure();

      var se = new SchemaExport(configuration);

      SqlConnection conn = new SqlConnection(configuration.Properties["connection.connection_string"]);
      conn.Open();

      var command = conn.CreateCommand();

      command.CommandText = @"
DECLARE @sql NVARCHAR(max)=''
SELECT @sql=@sql+' Drop table [' + s.NAME + '].[' + t.NAME+'];'
FROM   sys.tables t
       JOIN sys.schemas s
         ON t.[schema_id] = s.[schema_id]
WHERE  t.type = 'U'
Exec sp_executesql @sql;
select @sql = ''
SELECT @sql=@sql+' Drop table [' + s.NAME + '].[' + t.NAME+'];'
FROM   sys.tables t
       JOIN sys.schemas s
         ON t.[schema_id] = s.[schema_id]
WHERE  t.type = 'U';
select @sql";

      conn.Close();


      se.Drop(true, true);

      se.Create(true, true);

      _sessionFactory = configuration.BuildSessionFactory();
    }
    static bool IsSubclassOfRawGeneric(System.Type generic, System.Type toCheck)
    {
      while (toCheck != null && toCheck != typeof(object))
      {
        var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
        if (generic == cur)
        {
          return true;
        }
        toCheck = toCheck.BaseType;
      }
      return false;
    }
  }
}