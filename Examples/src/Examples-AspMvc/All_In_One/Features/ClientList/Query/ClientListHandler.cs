using AspMvc.Examples.Common.Client.Query;

namespace All_In_One.Features.ClientList.Query
{
  public class ClientListHandler : IQueryHandler<ClientListQuery>
  {
    private IClientQueryRepository _clientQueryRepository;

    public ClientListHandler(IClientQueryRepository clientQueryRepository)
    {
      _clientQueryRepository = clientQueryRepository;
    }

    public ClientListQuery Handle()
    {
      ClientListQuery clientListQuery = new ClientListQuery();
      clientListQuery.Clients = _clientQueryRepository.GetAll();
      return clientListQuery;
    }
  }
}