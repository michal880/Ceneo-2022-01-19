namespace GOF.Behavioral.Command.Example1
{
  internal interface ICommand
  {
    void Execute();

    void Undo();
  }
}