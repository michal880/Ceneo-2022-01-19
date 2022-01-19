using All_In_One.Features.ClientList;
using Castle.Windsor;

namespace AspMvc.Infrastructure.CommandHandler
{
  public class QueryDispatcher : IQueryDispatcher
  {
    private IWindsorContainer _container;

    public QueryDispatcher(IWindsorContainer container)
    {
      _container = container;
    }

    public T Handle<T>()
    {
      IQueryHandler<T> queryHandler = _container.Resolve<IQueryHandler<T>>();
      return queryHandler.Handle();
    }

    public T Handle<T, U>(U query)
    {
      IQueryHandler<T,U> queryHandler = _container.Resolve<IQueryHandler<T,U>>();
      return queryHandler.Handle(query);
    }
  }
}