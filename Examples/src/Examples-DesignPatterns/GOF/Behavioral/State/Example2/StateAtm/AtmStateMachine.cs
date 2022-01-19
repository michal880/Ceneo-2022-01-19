using GOF.Behavioral.State.Example2.StateAtm.States;

namespace GOF.Behavioral.State.Example2.StateAtm
{
  internal class AtmStateMachine : IAtmMachineInternal, IAtmMachine
  {
    private IAtmState _currentState;

    public IAtmState Initial { get; private set; }

    public IAtmState CardInserted { get; private set; }

    public IAtmState PinEntered { get; private set; }

    public IAtmState CashWithdrawn { get; private set; }

    public IAtmState NoCash { get; private set; }

    public Money CashAmount { get; private set; }

    public AtmStateMachine(Money cash)
    {
      _currentState = Initial = new InitialState(this);
      CardInserted = new CardInserted(this);
      PinEntered = new PinEntered(this);
      CashWithdrawn = new CashWithdrawn(this);
      CashAmount = cash;
    }

    public void InsertCard()
    {
      _currentState.InsertCard();
    }

    public void EnterPin(Pin pin)
    {
      _currentState.EnterPin(pin);
    }

    public void WithdrawCash(Money amount)
    {
      _currentState.WithdrawMoney(amount);
    }

    public void RemoveCard()
    {
      _currentState.RemoveCard();
    }

    public void SetCash(Money money)
    {
      CashAmount = money;
    }

    public void SetState(IAtmState newState)
    {
      _currentState = newState;
    }
  }
}