using System.Collections.Generic;

namespace FeatureFolders.Implementation.Client.Query
{
  public interface IClientQueryRepository
  {
    IEnumerable<ClientSummary> GetAll();
    IEnumerable<ClientType> GetClientTypes();
  }
}