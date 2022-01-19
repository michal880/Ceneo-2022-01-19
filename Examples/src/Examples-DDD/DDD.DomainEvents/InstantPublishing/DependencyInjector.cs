using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Windsor;

namespace DDD.DomainEvents.InstantPublishing
{
  public class DependencyInjector : IDependencyInjector
  {
    private readonly IWindsorContainer _container;

    public DependencyInjector(IWindsorContainer container)
    {
      _container = container;
    }

    private static IEnumerable<FieldInfo> GetFields(object obj)
    {
      Type t = obj.GetType();

      var fields = new List<FieldInfo>();

      while (t != typeof(object))
      {
        fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

        t = t.BaseType;
      }

      return fields;
    }

    public static void InjectDependency(object o, object dependency)
    {
      var fields = GetFields(o);
      foreach (FieldInfo fieldInfo in fields)
      {
        if (fieldInfo.FieldType.IsAssignableFrom(dependency.GetType()))
        {
          fieldInfo.SetValue(o, dependency);
        }
      }
    }

    public void InjectDependencies(AggregateRootWithEventPublisher aggregateRoot)
    {
      var fields = GetFields(aggregateRoot);
      foreach (FieldInfo fieldInfo in fields)
      {
        if (fieldInfo.FieldType.IsInterface)
        {
          object iface = _container.Resolve(fieldInfo.FieldType);
          fieldInfo.SetValue(aggregateRoot, iface);
        }
      }
    }
  }
}