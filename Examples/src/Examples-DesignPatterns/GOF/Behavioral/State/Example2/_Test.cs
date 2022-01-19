using GOF.Behavioral.State.Example2.NoStateAtm;
using NUnit.Framework;

namespace GOF.Behavioral.State.Example2
{
  [TestFixture]
  public class _Test
  {
    private IAtmMachine _sut = new NoStateAtmMachine(new Money(33333));
    //IAtmMachine atmMachine = new AtmMachine(new Money(33333));

    [Test]
    public void HappyScenario()
    {
      _sut.InsertCard();
      _sut.EnterPin(new Pin(1234));
      _sut.WithdrawCash(new Money(123));
      _sut.RemoveCard();
    }
  }
}