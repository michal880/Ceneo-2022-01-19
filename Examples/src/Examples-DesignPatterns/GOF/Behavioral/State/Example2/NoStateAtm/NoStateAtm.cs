using System;

namespace GOF.Behavioral.State.Example2.NoStateAtm
{
  internal class NoStateAtmMachine : IAtmMachine
  {
    private readonly Money _value;

    private enum MACHINE_STATE
    {
      INITIAL,
      CARD_INSERTED,
      PIN_ENTERED,
      CASH_WITHDRAWN,
    }

    private MACHINE_STATE _currentState = MACHINE_STATE.INITIAL;

    public NoStateAtmMachine(Money value)
    {
      _value = value;
    }

    public void InsertCard()
    {
      switch (_currentState)
      {
        case MACHINE_STATE.INITIAL:
          _currentState = MACHINE_STATE.CARD_INSERTED;
          break;

        case MACHINE_STATE.CARD_INSERTED:
        case MACHINE_STATE.PIN_ENTERED:
        case MACHINE_STATE.CASH_WITHDRAWN:
          throw new InvalidOperationException("Card already inserted");
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void EnterPin(Pin pin)
    {
      switch (_currentState)
      {
        case MACHINE_STATE.INITIAL:
          throw new InvalidOperationException("No card inserted");

        case MACHINE_STATE.CARD_INSERTED:
          if (pin != 1234)
          {
            throw new InvalidOperationException("incorect pin");
          }
          _currentState = MACHINE_STATE.PIN_ENTERED;
          break;

        case MACHINE_STATE.PIN_ENTERED:
        case MACHINE_STATE.CASH_WITHDRAWN:
          throw new InvalidOperationException("Pin already entered");

        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void WithdrawCash(Money amount)
    {
      switch (_currentState)
      {
        case MACHINE_STATE.INITIAL:
          throw new InvalidOperationException("No card inserted");

        case MACHINE_STATE.CARD_INSERTED:
          throw new InvalidOperationException("Pin not entered");

        case MACHINE_STATE.PIN_ENTERED:
          if (_value < amount)
          {
            throw new InvalidOperationException("Not enough cash");
          }
          _currentState = MACHINE_STATE.CASH_WITHDRAWN;
          break;

        case MACHINE_STATE.CASH_WITHDRAWN:
          throw new InvalidOperationException("Cash already returned");

        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void RemoveCard()
    {
      switch (_currentState)
      {
        case MACHINE_STATE.INITIAL:
          throw new InvalidOperationException("No card inserted");

        case MACHINE_STATE.CARD_INSERTED:
        case MACHINE_STATE.PIN_ENTERED:
        case MACHINE_STATE.CASH_WITHDRAWN:
          _currentState = MACHINE_STATE.INITIAL;
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}