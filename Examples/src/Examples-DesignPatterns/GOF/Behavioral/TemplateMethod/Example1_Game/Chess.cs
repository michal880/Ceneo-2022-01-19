namespace GOF.Behavioral.TemplateMethod.Example1_Game
{
  //Now we can extend this class in order
  //to implement actual games:

  public class Chess : TurnBaseGame
  {
    /* Implementation of necessary concrete methods */

    protected override void InitializeGame()
    {
      // Initialize players
      // Put the pieces on the board
    }

    protected override void MakePlay(int player)
    {
      // Process a turn for the player
    }

    protected override bool EndOfGame()
    {
      // Return true if in Checkmate or
      // Stalemate has been reached
      return true;
    }

    protected override void PrintWinner()
    {
      // Display the winning player
    }
  }
}