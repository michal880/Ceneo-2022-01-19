using System.Collections.Generic;
using System.Linq;
using AspMvc.Examples.Common.Client.Command;
using AspMvc.Examples.Common.Client.Query;

namespace AspMvc.Examples.Common.Client.Impl
{
  public class ClientRepository : IClientCommandRepository, IClientQueryRepository
  {
    static Dictionary<int, Command.Client> _clients = new Dictionary<int, Command.Client>();

    static ClientRepository()
    {
      _clients.Add(1, new Command.Client() { Id = 1, Name = "Microsoft", TaxId = "1234567890" });
      _clients.Add(2, new Command.Client() { Id = 2, Name = "Google", TaxId = "1234567890" });
      _clients.Add(3, new Command.Client() { Id = 3, Name = "Apple", TaxId = "1234567890" });
    }

    public Command.Client Get(int id)
    {
      return _clients[id];
    }

    public void Update(Command.Client client)
    {
      _clients[client.Id] = client;
    }

    public void Add(Command.Client client)
    {
      client.Id = _clients.Count + 1;
      _clients.Add(client.Id, client);
    }

    public bool ClientExist(string taxId)
    {
      return _clients.Any(f => f.Value.TaxId == taxId);
    }

    public IEnumerable<ClientSummary> GetAll()
    {
      return _clients.Values.Select(f => new ClientSummary() {Id = f.Id, Name = f.Name});
    }

    public IEnumerable<ClientType> GetClientTypes()
    {
      return new[]
      {
        new ClientType(1, "Jednoosobowy przedsiębiorca"), 
        new ClientType(2, "Sp. z o.o."), 
        new ClientType(3, "S.A.")
      };
    }
  }
}