namespace BridgeDesignPattern.Example2
{
  internal class WelCommeMessage : IMessage
  {
    private readonly string _email;
    private readonly IMessageSender _messageSender;

    public WelCommeMessage(string email, IMessageSender messageSender)
    {
      _email = email;
      _messageSender = messageSender;
    }

    public void Send()
    {
      _messageSender.SendMessage("WelCommeMessage;" + _email);
    }
  }
}