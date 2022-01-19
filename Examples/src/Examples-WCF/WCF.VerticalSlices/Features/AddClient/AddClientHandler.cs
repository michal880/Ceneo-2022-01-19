using System;
using WCF.VerticalSlices.Infrastructure;

namespace WCF.VerticalSlices.Features.AddClient
{
  public class AddClientHandler : ICommandHandler<AddClientCommand>
  {
    public AddClientHandler()
    {
    }

    public void Handle(AddClientCommand command)
    {
      Console.WriteLine("Command arrived");
    }
  }
}