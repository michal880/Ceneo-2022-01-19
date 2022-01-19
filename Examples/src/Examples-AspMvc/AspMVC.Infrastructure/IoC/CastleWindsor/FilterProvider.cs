using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.ComponentActivator;
using Castle.Windsor;

namespace AspMvc.Infrastructure.IoC.CastleWindsor
{
  internal class FilterProvider : FilterAttributeFilterProvider
  {
    private IWindsorContainer _container;

    public FilterProvider(IWindsorContainer container)
    {
      _container = container;
    }

    public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
    {
      IEnumerable<Filter> filters = base.GetFilters(controllerContext, actionDescriptor);
      foreach (Filter filter in filters)
      {
        InjectProperties(_container, filter);
      }
      return filters;
    }
  
    private static void InjectProperties(IWindsorContainer container, object target)
    {
      var type = target.GetType();
      foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
      {
        if (property.CanWrite && container.Kernel.HasComponent(property.PropertyType))
        {
          var value = container.Resolve(property.PropertyType);
          try
          {
            property.SetValue(target, value, null);
          }
          catch (Exception ex)
          {
            var message = string.Format("Error setting property {0} on type {1}, See inner exception for more information.", property.Name, type.FullName);
            throw new ComponentActivatorException(message, ex, null);
          }
        }
      }
    }
  }
}