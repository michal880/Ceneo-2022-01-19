using System;

namespace GOF.Behavioral.State.Example2.StateAtm.States
{
  internal class PinEntered : BaseState
  {
    public PinEntered(IAtmMachineInternal machine)
      : base(machine)
    {
    }

    public override void InsertCard()
    {
      throw new InvalidOperationException("Card already inserted");
    }

    public override void EnterPin(Pin pin)
    {
      throw new InvalidOperationException("Pin already entered");
    }

    public override void WithdrawMoney(Money amount)
    {
      if (_machine.CashAmount < amount)
      {
        throw new InvalidOperationException("Not enough cash");
      }
      _machine.SetCash(_machine.CashAmount - amount);
      _machine.SetState(_machine.CashWithdrawn);
    }

    public override void RemoveCard()
    {
      _machine.SetState(_machine.Initial);
    }
  }
}