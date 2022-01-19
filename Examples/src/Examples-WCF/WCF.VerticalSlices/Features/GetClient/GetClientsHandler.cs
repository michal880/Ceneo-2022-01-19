using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.VerticalSlices.Infrastructure;
using WCF.VerticalSlices.Infrastructure.Dispatcher;

namespace WCF.VerticalSlices.Features.GetClient
{
  public class GetClientsHandler : IQueryHandler<GetClientsQuery>
  {
    public QueryResponse Handle(GetClientsQuery request)
    {
      return new GetClientsResponse();
    }
  }
}
