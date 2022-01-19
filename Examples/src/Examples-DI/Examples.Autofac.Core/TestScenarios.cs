namespace Examples.Autofac.Core
{
  public class TestScenarios
  {
    [Fact]  
    public void RegisterType()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Configuration>().As<IConfiguration>();
      builder.RegisterType<Repository>().As<IRepository>();
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<IRepository>());
    }

    [Fact]
    public void RegisterTypeNoInterfaceConfiguration()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Configuration>().AsImplementedInterfaces();
      builder.RegisterType<Repository>().As<IRepository>();
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<IRepository>());
    }

    [Fact]
    public void RegisterAllTypesInAssembly()
    {
      var builder = new ContainerBuilder();
      builder.RegisterAssemblyTypes(this.GetType().Assembly).AsImplementedInterfaces();      
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<IRepository>());
    }

    [Fact]
    public void Lambda()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Configuration>().As<IConfiguration>();
      builder.Register(context => new Repository(context.Resolve<IConfiguration>())).As<IRepository>();
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<IRepository>());
    }

    [Fact]
    public void Instance()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Repository>().As<IRepository>();
      builder.RegisterInstance(new Repository(new Configuration())).As<IRepository>();
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<IRepository>());
    }

    [Fact]
    public void ScopeSingleton()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Repository>().As<IRepository>().SingleInstance();//.InstancePerDependency();      
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<IRepository>());
    }

    [Fact]
    public void RegisterAgain()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Repository>().As<IRepository>();
      builder.RegisterType<TestRepository>().As<IRepository>();
      IContainer container = builder.Build();

      Assert.True(container.Resolve<IRepository>().GetType() == typeof(TestRepository));
    }


    [Fact]
    public void InstancePerLifetime()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Configuration>().As<IConfiguration>().InstancePerLifetimeScope();
      builder.RegisterType<Repository>().As<IRepository>().InstancePerLifetimeScope();      
      IContainer container = builder.Build();

      using (var scope1 = container.BeginLifetimeScope())
      {
        var a = scope1.Resolve<IRepository>();
        for (var i = 0; i < 100; i++)
        {
          // Every time you resolve this from within this
          // scope you'll get the same instance.
          var b = scope1.Resolve<IRepository>();

          Assert.Equal(a, b);
        }
      }
      
    }

    [Fact]
    public void Disposable()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<DisposableComponent>().As<IDisposableComponent>().InstancePerLifetimeScope();
      IContainer container = builder.Build();

      using (var scope1 = container.BeginLifetimeScope())
      {
        var a = scope1.Resolve<IDisposableComponent>();        
      }

      Assert.True(DisposableComponent.Disposed);
    }

    [Fact]
    public void Module()
    {
      var builder = new ContainerBuilder();
      builder.RegisterModule<MyModule>();
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<ISomeDependency>());
    }

    [Fact]
    public void PropertyInjection()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<PropertyDependency>().AsImplementedInterfaces();
      builder.RegisterType<Controller>().AsImplementedInterfaces().PropertiesAutowired();
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<IController>().Dependency);
    }

    [Fact]
    public void PassValueToConstructor()
    {
      string connectionString = "aaa";

      var builder = new ContainerBuilder();
      builder.RegisterType<RepositoryWithConstructorParameter>().WithParameter("connectionString", connectionString);      
      IContainer container = builder.Build();

      Assert.Equal(connectionString, container.Resolve<RepositoryWithConstructorParameter>().ConnectionString);
    }

    [Fact]
    public void Keyed()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Configuration>().As<IConfiguration>();
      builder.RegisterType<Repository>().Keyed<IRepository>("a");
      builder.RegisterType<TestRepository>().Keyed<IRepository>("b");
      
      IContainer container = builder.Build();

      var repoA = container.ResolveKeyed<IRepository>("a");
      Assert.Equal(typeof(Repository), repoA.GetType());

      var repoB = container.ResolveKeyed<IRepository>("b");
      Assert.Equal(typeof(TestRepository), repoB.GetType());
    }

    [Fact]
    public void Interception()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<Configuration>().As<IConfiguration>();
      builder.RegisterType<LoggingAspect>();

      builder
        .RegisterType<Repository>()
        .As<IRepository>()
        .EnableInterfaceInterceptors()
        .InterceptedBy(typeof(LoggingAspect)); 

      IContainer container = builder.Build();

      container.Resolve<IRepository>().Add();

      Assert.Equal(1, LoggingAspect.ExecutionCounter);
    }

    [Fact]
    public void GenericRegistrations()
    {
      var builder = new ContainerBuilder();
      builder.RegisterGeneric(typeof(CommandHandler<>)).As(typeof(ICommandHandler<>));
      IContainer container = builder.Build();

      Assert.NotNull(container.Resolve<ICommandHandler<string>>());
    }
  }
}