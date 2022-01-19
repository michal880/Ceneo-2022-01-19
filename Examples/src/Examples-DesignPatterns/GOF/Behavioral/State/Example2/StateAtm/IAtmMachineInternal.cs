namespace GOF.Behavioral.State.Example2.StateAtm
{
  internal interface IAtmMachineInternal
  {
    void SetState(IAtmState newState);

    void SetCash(Money money);

    IAtmState CardInserted { get; }

    IAtmState PinEntered { get; }

    IAtmState CashWithdrawn { get; }

    IAtmState NoCash { get; }

    IAtmState Initial { get; }

    Money CashAmount { get; }
  }
}