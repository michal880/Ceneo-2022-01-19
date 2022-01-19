using System;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Infrastructure.CommandHandler;

namespace CommandPattern.Controllers.CreateClient
{
  public class ClientCreateCommandHandler : ICommandHandler<ClientCreateCommand>
  {
    private IClientCommandRepository _clientCommandRepository;

    public ClientCreateCommandHandler(IClientCommandRepository clientCommandRepository)
    {
      _clientCommandRepository = clientCommandRepository;
    }

    public void Handle(ClientCreateCommand command)
    {
      Client client = new Client();
      client.Name = command.Name;
      _clientCommandRepository.Add(client);
    }
  }
}