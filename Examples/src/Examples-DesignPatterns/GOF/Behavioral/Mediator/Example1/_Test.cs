using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GOF.Behavioral.Mediator.Example1
{
  [TestFixture]
  public class _Test
  {
    public void Test()
    {
      IChatClient<string> chatClientA = new ChatClient<string>("ColleagueA");
      IChatClient<string> chatClientB = new ChatClient<string>("ColleagueB");
      IChatClient<string> chatClientC = new ChatClient<string>("ColleagueC");
      
      IMediator<string> mediator1 = new ConcreteMediator<string>();

      mediator1.Register(chatClientA);
      mediator1.Register(chatClientB);
      mediator1.Register(chatClientC);

      chatClientA.SendMessage(mediator1, "MessageX from A");      
    }
  }
}
