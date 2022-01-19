using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Examples.Autofac.Module
{
    public class MyModule : global::Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<SomeDependency>().AsImplementedInterfaces();
      }
    }
}
