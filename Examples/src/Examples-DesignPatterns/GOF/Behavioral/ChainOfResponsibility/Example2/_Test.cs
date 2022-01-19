using NUnit.Framework;

namespace GOF.Behavioral.ChainOfResponsibility.Example2
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Process_should_process_with_proper_handler()
    {
      Command cmd = new AddCommand();
      //Command cmd = new RemoveCommand();

      ProcessorBase processor = new RemoveCommandProcessor(new AddCommandProcessor(null));

      object response = processor.Process(cmd);

      Assert.IsNotNull(response);
    }
  }
}