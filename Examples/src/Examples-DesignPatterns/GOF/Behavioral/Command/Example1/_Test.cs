using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF.Behavioral.Command.Example1
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void TurnOnCommandTest() // Client
    {
      Light light = new Light();// Receiver

      ICommand command = new TurnOnCommand(light);

      command.Execute();
      command.Undo();
    }
  }
}