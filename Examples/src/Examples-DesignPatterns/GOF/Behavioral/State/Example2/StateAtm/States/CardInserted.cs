using System;

namespace GOF.Behavioral.State.Example2.StateAtm.States
{
  internal class CardInserted : BaseState
  {
    public CardInserted(IAtmMachineInternal machine)
      : base(machine)
    {
    }

    public override void InsertCard()
    {
      throw new InvalidOperationException("Card already inserted");
    }

    public override void EnterPin(Pin pin)
    {
      if (pin != 1234)
      {
        throw new InvalidOperationException("incorect pin");
      }

      _machine.SetState(_machine.PinEntered);
    }

    public override void WithdrawMoney(Money amount)
    {
      throw new InvalidOperationException("Please enter pin");
    }

    public override void RemoveCard()
    {
      _machine.SetState(_machine.Initial);
    }
  }
}