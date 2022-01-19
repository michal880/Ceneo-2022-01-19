using System;

namespace GOF.Behavioral.State.Example2.StateAtm.States
{
  internal class InitialState : BaseState
  {
    public InitialState(IAtmMachineInternal machine)
      : base(machine)
    {
    }

    public override void InsertCard()
    {
      _machine.SetState(_machine.CardInserted);
    }

    public override void EnterPin(Pin pin)
    {
      throw new InvalidOperationException("No card inserted");
    }

    public override void WithdrawMoney(Money amount)
    {
      throw new InvalidOperationException("No card inserted");
    }

    public override void RemoveCard()
    {
      throw new InvalidOperationException("No card inserted");
    }
  }
}