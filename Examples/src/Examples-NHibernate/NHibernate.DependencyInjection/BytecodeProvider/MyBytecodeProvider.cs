using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using NHibernate.Bytecode;
using NHibernate.Properties;
using NHibernate.Type;
using NHibernate.Util;
using uNhAddIns.CastleAdapters.EnhancedBytecodeProvider;

namespace NHibernate.DependencyInjection.BytecodeProvider
{
  class MyBytecodeProvider : IBytecodeProvider
  {
    private readonly IWindsorContainer _container;
    private System.Type _collectionTypeFactoryClass = typeof(DefaultCollectionTypeFactory);
    private System.Type _proxyFactoryFactory;
    private ICollectionTypeFactory _collectionTypeFactory;

    public MyBytecodeProvider(IWindsorContainer container)
    {
      _container = container;
      ObjectsFactory = new CastleObjectsFactory(_container);
    }
    public IReflectionOptimizer GetReflectionOptimizer(System.Type clazz, IGetter[] getters, ISetter[] setters)
    {
      return new CastleReflectionOptimizer(_container, clazz, getters, setters);
    }
  
    
    public virtual IProxyFactoryFactory ProxyFactoryFactory
    {
      get
      {
        if (!(_proxyFactoryFactory != (System.Type)null))
          return (IProxyFactoryFactory)new DefaultProxyFactoryFactory();
        try
        {
          return (IProxyFactoryFactory)ObjectsFactory.CreateInstance(_proxyFactoryFactory);
        }
        catch (Exception ex)
        {
          throw new HibernateByteCodeException("Failed to create an instance of '" + _proxyFactoryFactory.FullName + "'!", ex);
        }
      }
    }

    public virtual IObjectsFactory ObjectsFactory { get; }

    public virtual ICollectionTypeFactory CollectionTypeFactory
    {
      get
      {
        if (_collectionTypeFactory == null)
        {
          try
          {
            _collectionTypeFactory = (ICollectionTypeFactory)ObjectsFactory.CreateInstance(_collectionTypeFactoryClass);
          }
          catch (Exception ex)
          {
            throw new HibernateByteCodeException("Failed to create an instance of CollectionTypeFactory!", ex);
          }
        }
        return _collectionTypeFactory;
      }
    }    

    public virtual void SetProxyFactoryFactory(string typeName)
    {
      System.Type c;
      try
      {
        c = ReflectHelper.ClassForName(typeName);
      }
      catch (Exception ex)
      {
        throw new UnableToLoadProxyFactoryFactoryException(typeName, ex);
      }
      if (!typeof(IProxyFactoryFactory).IsAssignableFrom(c))
        throw new HibernateByteCodeException(c.FullName + " does not implement " + typeof(IProxyFactoryFactory).FullName);
      _proxyFactoryFactory = c;
    }

    public void SetCollectionTypeFactoryClass(string typeAssemblyQualifiedName)
    {
      if (string.IsNullOrEmpty(typeAssemblyQualifiedName))
        throw new ArgumentNullException(nameof(typeAssemblyQualifiedName));
      SetCollectionTypeFactoryClass(ReflectHelper.ClassForName(typeAssemblyQualifiedName));
    }

    public void SetCollectionTypeFactoryClass(System.Type type)
    {
      if (type == (System.Type)null)
        throw new ArgumentNullException("type");
      if (!typeof(ICollectionTypeFactory).IsAssignableFrom(type))
        throw new HibernateByteCodeException(type.FullName + " does not implement " + typeof(ICollectionTypeFactory).FullName);
      if (_collectionTypeFactory != null && !_collectionTypeFactoryClass.Equals(type))
        throw new InvalidOperationException("CollectionTypeFactory in use, can't change it.");
      _collectionTypeFactoryClass = type;
    }
  }
}
