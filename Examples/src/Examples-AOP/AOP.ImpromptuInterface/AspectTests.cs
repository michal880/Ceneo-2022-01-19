using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AOP.ImpromptuInterface
{
  [TestFixture]
  public class AspectTests
  {
    [Test]
    public void Aspect_should_ceate_transaction_around_handle_method()
    {
      // Arrange
      ICommandHandler<MyCommand> command = TransactionAspect<ICommandHandler<MyCommand>>.Create(new MyCommanHandler());

      // Act, Assert
      Assert.DoesNotThrow(() => command.Handle(new MyCommand()));
    }
  }
}
