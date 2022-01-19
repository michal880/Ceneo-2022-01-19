using System.Runtime.Serialization;
using WCF.VerticalSlices.Infrastructure.Dispatcher;

namespace WCF.VerticalSlices.Features.GetClient
{
  [DataContract]
  public class GetClientsQuery : QueryRequest
  {
  }
}