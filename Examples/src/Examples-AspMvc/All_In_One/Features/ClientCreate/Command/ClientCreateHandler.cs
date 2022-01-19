using AspMvc.Examples.Common.Client.Command;
using AspMvc.Infrastructure.CommandHandler;

namespace All_In_One.Features.ClientCreate.Command
{
  public class ClientCreateHandler : ICommandHandler<ClientCreateCommand>
  {
    private IClientCommandRepository _clientCommandRepository;

    public ClientCreateHandler(IClientCommandRepository clientCommandRepository)
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