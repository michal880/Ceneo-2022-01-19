namespace BridgeDesignPattern.Example2
{
  internal class NewLoginMessage : IMessage
  {
    private readonly string _email;
    private readonly IMessageSender _messageSender;

    public NewLoginMessage(string email, IMessageSender messageSender)
    {
      _email = email;
      _messageSender = messageSender;
    }

    public void Send()
    {
      _messageSender.SendMessage("NewLoginMessage;" + _email+";"+CreatePassword());
    }

    private string CreatePassword()
    {
      return "NewPassword";
    }
  }
}