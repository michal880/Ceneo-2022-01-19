using System;
using System.Diagnostics;
using Castle.Windsor;
using NHibernate.Bytecode;
using NHibernate.DependencyInjection;

namespace uNhAddIns.CastleAdapters.EnhancedBytecodeProvider
{
	public class CastleObjectsFactory : IObjectsFactory
	{
		private readonly IWindsorContainer container;

		public CastleObjectsFactory(IWindsorContainer container)
		{
			this.container = container;
		}

		public object CreateInstance(Type type)
		{
		  if (type == typeof(Order))
		  {

		  }
      return container.Kernel.HasComponent(type) ? container.Resolve(type) : Activator.CreateInstance(type);
		}

		public object CreateInstance(Type type, bool nonPublic)
		{
		  if (type == typeof(Order))
		  {

		  }
      return container.Kernel.HasComponent(type) ? container.Resolve(type) : Activator.CreateInstance(type, nonPublic);
		}

		public object CreateInstance(Type type, params object[] ctorArgs)
		{
		  if (type == typeof(Order))
		  {

		  }
      return Activator.CreateInstance(type, ctorArgs);
		}
	}
}