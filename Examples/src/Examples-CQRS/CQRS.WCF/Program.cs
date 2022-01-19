using System;
using System.ServiceModel;
using CQRS.WCF.Features.InventoryItem;
using CQRS.WCF.Infrastructure.Dispatcher;
using CQRS.WCF.Infrastructure.Ioc;

namespace CQRS.WCF
{
  class Program
  {
    static void Main(string[] args)
    {
      StructureMapServiceHost sh = new StructureMapServiceHost(typeof(Dispatcher));
      sh.Open();

      ChannelFactory<IDispatcher> channelFactory = new ChannelFactory<IDispatcher>("*");

      var requestProcessor = channelFactory.CreateChannel();

      requestProcessor.Send(new CreateInventoryItemCommand());

      Console.WriteLine("Press any key to continue ...");
      Console.ReadKey();

      sh.Close(new TimeSpan(0,0,1));
    }
  }
}
