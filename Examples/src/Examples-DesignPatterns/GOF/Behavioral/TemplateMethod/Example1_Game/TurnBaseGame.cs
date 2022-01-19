namespace GOF.Behavioral.TemplateMethod.Example1_Game
{
  public abstract class TurnBaseGame
  {
    protected int _playersCount;

    protected abstract void InitializeGame();

    protected abstract void MakePlay(int player);

    protected abstract bool EndOfGame();

    protected abstract void PrintWinner();

    /* A template method : */

    public void PlayOneGame(int playersCount)
    {
      _playersCount = playersCount;
      InitializeGame();
      int j = 0;
      while (!EndOfGame())
      {
        MakePlay(j);
        j = (j + 1) % playersCount;
      }
      PrintWinner();
    }
  }
}