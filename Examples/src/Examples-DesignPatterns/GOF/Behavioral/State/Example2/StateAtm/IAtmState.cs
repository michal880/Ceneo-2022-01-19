namespace GOF.Behavioral.State.Example2.StateAtm
{
  public interface IAtmState
  {
    void InsertCard();

    void EnterPin(Pin pin);

    void WithdrawMoney(Money amount);

    void RemoveCard();
  }
}