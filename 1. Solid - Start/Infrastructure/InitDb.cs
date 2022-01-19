using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbUp;
using SOLID_Example.Scripts;

namespace SOLID_Example.Infrastructure
{
  public class InitDb
  {
    public static void Run(string connectionString)
    {
      AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

      var upgrader = DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(typeof(ScriptsDummyClass).Assembly, s => s.StartsWith(typeof(ScriptsDummyClass).Namespace))
        .LogToConsole()
        .Build();

      if (!upgrader.PerformUpgrade().Successful)
      {
        throw new Exception("Cannot update db");
      }
    }
  }
}
