using System.Collections.Generic;

namespace AspMvc.Examples.Common.Client.Query
{
  public interface IClientQueryRepository
  {
    IEnumerable<ClientSummary> GetAll();
    IEnumerable<ClientType> GetClientTypes();
  }
}