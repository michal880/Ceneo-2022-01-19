using System;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.VerticalSlices.Features.AddClient;
using WCF.VerticalSlices.Features.GetClient;
using WCF.VerticalSlices.Infrastructure;
using WCF.VerticalSlices.Infrastructure.Dispatcher;
using WCF.VerticalSlices.Infrastructure.Ioc;

namespace WCF.VerticalSlices
{
  class Program
  {
    static void Main(string[] args)
    {
      StructureMapServiceHost sh = new StructureMapServiceHost(typeof(Dispatcher));
      sh.Open();

      ChannelFactory<IDispatcher> channelFactory = new ChannelFactory<IDispatcher>("*");

      var requestProcessor = channelFactory.CreateChannel();

      requestProcessor.Send(new AddClientCommand());

      var result = requestProcessor.Query(new GetClientsQuery());

      Console.WriteLine("Press any key to continue ...");
      Console.ReadKey();

      sh.Close(new TimeSpan(0,0,1));
    }
  }
}
