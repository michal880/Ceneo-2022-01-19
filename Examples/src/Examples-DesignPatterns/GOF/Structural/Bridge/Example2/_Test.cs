using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BridgeDesignPattern.Example2
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void test1()
    {
      IMessage[] messages = CreateClient("Name", "nasza@firma.pl", "ul Pomorska 12 12-123 Warszawa");

      foreach (var message in messages)
      {
        message.Send();
      }
    }

    private IMessage[] CreateClient(string name, string email, string address)
    {
      IMessageSender msmqMessageSender = new MSMQMessageSender();
      IMessageSender emailMessageSender = new EmailMessageSender();

      return new IMessage[]
        {
          new NewCilentMessage(name, email, address, msmqMessageSender),
          new NewLoginMessage(email, emailMessageSender),
          new WelCommeMessage(email, emailMessageSender)
        };
    }
  }

  internal class EmailMessageSender : IMessageSender
  {
    public void SendMessage(string data)
    {
      Console.WriteLine("EmailMessageSender: Sending data - {0}",data);
    }
  }

  internal class MSMQMessageSender : IMessageSender
  {
    public void SendMessage(string data)
    {
      Console.WriteLine("MSMQMessageSender: Sending data - {0}", data);
    }
  }
}
