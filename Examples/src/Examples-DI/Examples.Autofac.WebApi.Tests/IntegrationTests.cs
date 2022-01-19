using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using Autofac.Extensions.DependencyInjection;

namespace Examples.Autofac.WebApi.Tests
{
  public class IntegrationTests
  {
    [Fact]
    public void ServiceTest()
    {
      Startup.BuildFunc = builder => { builder.RegisterModule<AutofacModule4Testing>(); };

      IWebHost host = WebHost.CreateDefaultBuilder()
        .UseKestrel()
        .ConfigureServices(services => services.AddAutofac())
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      ThreadPool.QueueUserWorkItem(f=> host.Run());

      using (HttpClient client = new HttpClient())
      {
        Task<string> result = client.GetStringAsync("http://localhost:5000/api/Values/");
        result.Wait();
        Assert.True(result.Result.Contains("Test"));
      }
    }
  }
}
