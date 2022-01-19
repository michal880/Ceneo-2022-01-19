using System;
using Castle.Windsor;
using NHibernate.DependencyInjection;
using NHibernate.Properties;

namespace uNhAddIns.CastleAdapters.EnhancedBytecodeProvider
{
	public class CastleReflectionOptimizer : NHibernate.Bytecode.Lightweight.ReflectionOptimizer
	{
		private readonly IWindsorContainer container;

		public CastleReflectionOptimizer(IWindsorContainer container, Type mappedType, IGetter[] getters, ISetter[] setters)
			: base(mappedType, getters, setters)
		{
			this.container = container;
		}

		public override object CreateInstance()
		{
		  if (mappedType == typeof(Order))
		  {

		  }
			if (container.Kernel.HasComponent(mappedType))
			{
				return container.Resolve(mappedType);
			}
			else
			{
				return container.Kernel.HasComponent(mappedType.FullName)
						? container.Resolve(mappedType.FullName, new{})
				       	: base.CreateInstance();
			}
		}

		protected override void ThrowExceptionForNoDefaultCtor(Type type) {}
	}
}