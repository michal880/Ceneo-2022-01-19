namespace BridgeDesignPattern.Example2
{
  internal class NewCilentMessage : IMessage
  {
    private readonly string _name;
    private readonly string _email;
    private readonly string _address;
    private readonly IMessageSender _messageSender;

    public NewCilentMessage(string name, string email, string address, IMessageSender messageSender)
    {
      _name = name;
      _email = email;
      _address = address;
      _messageSender = messageSender;
    }

    public void Send()
    {
      _messageSender.SendMessage("NewCilentMessage;"+_name + ";" + _email + ";" + _address);
    }
  }
}