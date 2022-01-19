using System;

namespace GOF.Behavioral.State.Example2.StateAtm.States
{
  internal class CashWithdrawn : BaseState
  {
    public CashWithdrawn(IAtmMachineInternal machine)
      : base(machine)
    {
    }

    public override void InsertCard()
    {
      throw new InvalidOperationException("Card already inserted");
    }

    public override void EnterPin(Pin pin)
    {
      throw new InvalidOperationException("Card already inserted");
    }

    public override void WithdrawMoney(Money amount)
    {
      throw new InvalidOperationException("Card already inserted");
    }

    public override void RemoveCard()
    {
      _machine.SetState(_machine.Initial);
    }
  }
}