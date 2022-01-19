using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using SOLID_Example.Infrastructure;
using SOLID_TDD_Example;

namespace SOLID_Example
{
  internal static class Program
  {
    private class Currency
    {
      public string Name { get; }

      public decimal Price { get; }

      public Currency(string name, decimal price)
      {
        Name = name;
        Price = price;
      }
    }
    
    private static void Main(string[] args)
    {
      IConfiguration configuration = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json", true, true)
       .Build();
      var databaseSection = configuration.GetSection("ConnectionString");
      var connectionstring = databaseSection["ConnectionString"];
      

      InitDb.Run(connectionstring);

      if (args.Length > 1 && args[0] == "cleanup")
      {
        using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
        {
          using (IDbConnection connection = new SqlConnection(connectionstring))
          {
            Console.WriteLine("Administrative cleanup");
            connection.Execute("delete from Currency");
          }

          ts.Complete();
        }
      }
      else
      {
        using (var cli = new WebClient())
        {
          string data = cli.DownloadString("http://www.nbp.pl/kursy/xml/LastA.xml");

          using (IDbConnection connection = new SqlConnection(connectionstring))
          {
            IEnumerable<Currency> oldCurrencies = connection.Query<Currency>("select name,price from Currency");

            XElement xelement = XElement.Load(new StringReader(data));
            IEnumerable<Currency> currencies = from nm in xelement.Elements("pozycja")
              select new Currency(nm.Element("kod_waluty").Value, decimal.Parse(nm.Element("kurs_sredni").Value));

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
              connection.Execute("insert into Currency(name,price)Values(@Name,@Price)", currencies);
              ts.Complete();
            }

            foreach (var currency in oldCurrencies)
            {
              Currency newCurrency = currencies.FirstOrDefault(f => f.Name == currency.Name);
              if (newCurrency.Price != currency.Price)
              {
                Console.Write($"{newCurrency.Name} - {newCurrency.Price - currency.Price}");
              }
            }
          }
        }
      }
    }
  }
}