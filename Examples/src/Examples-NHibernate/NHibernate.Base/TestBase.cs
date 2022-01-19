using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using log4net;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;

namespace NHibernate.Mapping
{
  public class TestBase
  {
    private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected ISessionFactory _sessionFactory;

    //[SetUp]
    public void SetupBase()
    {
      log4net.Config.XmlConfigurator.Configure();

      AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

      Configuration configuration = new Configuration();
      configuration.DataBaseIntegration(f => f.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote);
      
      var mapper = new ModelMapper();

      var allEntities = GetType().Assembly.GetTypes().ToList();

      var mappings = allEntities.Where(t => IsSubclassOfRawGeneric(typeof(ClassMapping<>), t));
      mapper.AddMappings(mappings);
      var mapping = mapper.CompileMappingFor(allEntities);
      configuration.AddDeserializedMapping(mapping, "NHSchema");

      Configure(configuration);

      configuration.Configure();

      var se = new SchemaExport(configuration);

      SqlConnection conn = new SqlConnection(configuration.Properties["connection.connection_string"]);
      conn.Open();

      var command = conn.CreateCommand();

      command.CommandText = @"

DECLARE @SQL NVARCHAR(MAX)=''
SELECT @SQL = @SQL + 'ALTER TABLE ' + QUOTENAME(FK.TABLE_SCHEMA) + '.' + QUOTENAME(FK.TABLE_NAME) + ' DROP CONSTRAINT [' + RTRIM(C.CONSTRAINT_NAME) +'];' + CHAR(13)
--SELECT K_Table = FK.TABLE_NAME, FK_Column = CU.COLUMN_NAME, PK_Table = PK.TABLE_NAME, PK_Column = PT.COLUMN_NAME, Constraint_Name = C.CONSTRAINT_NAME
  FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
 INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK
    ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
 INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK
    ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
 INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU
    ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
 INNER JOIN (
            SELECT i1.TABLE_NAME, i2.COLUMN_NAME
              FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
             INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2
                ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
            WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
           ) PT
    ON PT.TABLE_NAME = PK.TABLE_NAME
EXEC (@SQL)

set @sql =''
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

      _log.Error("Tables left : "+command.ExecuteScalar());

      conn.Close();
      

      se.Drop(true, true);
      
      se.Create(true, true);

      _sessionFactory = configuration.BuildSessionFactory();
    }

    protected virtual void Configure(Configuration configuration)
    {
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