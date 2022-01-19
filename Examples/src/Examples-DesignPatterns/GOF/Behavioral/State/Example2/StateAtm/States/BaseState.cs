namespace GOF.Behavioral.State.Example2.StateAtm.States
{
  internal abstract class BaseState : IAtmState
  {
    protected readonly IAtmMachineInternal _machine;

    public BaseState(IAtmMachineInternal machine)
    {
      _machine = machine;
    }

    public abstract void InsertCard();

    public abstract void EnterPin(Pin pin);

    public abstract void WithdrawMoney(Money amount);

    public abstract void RemoveCard();
  }
}