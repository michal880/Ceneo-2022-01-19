namespace Examples.Autofac.Core
{
  public class RegistrationTest
  {
    [Fact]
    public void Resolve_CanResolveAllTypes()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Configuration>().As<IConfiguration>();
      builder.RegisterType<Repository>().As<IRepository>();
      var container = builder.Build();

      CheckRegistrations(container);
    }

    public void CheckRegistrations(IContainer container)
    {
      foreach (var componentRegistration in container.ComponentRegistry.Registrations)
      {
        foreach (var registrationService in componentRegistration.Services)
        {
          var registeredTargetType = registrationService.Description;
          var type = GetType(registeredTargetType);
          if (type == null)
          {
            Assert.True(false,$"Failed to parse type '{registeredTargetType}'");
          }
          var instance = container.Resolve(type);
          Assert.NotNull(instance);
          Assert.True(componentRegistration.Activator.LimitType.IsInstanceOfType(instance));
        }
      }
    }

    private static Type GetType(string typeName)
    {
      var type = Type.GetType(typeName);
      if (type != null)
      {
        return type;
      }
      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        type = assembly.GetType(typeName);
        if (type != null)
        {
          return type;
        }
      }
      return null;
    }
  }
}