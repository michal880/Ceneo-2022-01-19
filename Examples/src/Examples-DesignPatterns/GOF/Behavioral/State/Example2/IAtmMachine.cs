namespace GOF.Behavioral.State.Example2
{
  public interface IAtmMachine
  {
    void InsertCard();

    void EnterPin(Pin pin);

    void WithdrawCash(Money amount);

    void RemoveCard();
  }
}