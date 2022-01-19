namespace GOF.Behavioral.TemplateMethod.Example1_Game
{
  public class Monopoly : TurnBaseGame
  {
    /* Implementation of necessary concrete methods */

    protected override void InitializeGame()
    {
      // Initialize players
      // Initialize money
    }

    protected override void MakePlay(int player)
    {
      // Process one turn of player
    }

    protected override bool EndOfGame()
    {
      // Return true if game is over
      // according to Monopoly rules
      return false;
    }

    protected override void PrintWinner()
    {
      // Display who won
    }
  }
}