using System;
using AspMvc.Infrastructure.CommandHandler;

namespace IoC.Controllers
{
  public class CommandHandler : ICommandHandler<string>
  {
    public void Handle(string command)
    {
      throw new NotImplementedException();
    }
  }
}