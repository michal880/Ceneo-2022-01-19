using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VisitorPattern.Example1
{
  public class SpaceShip
  {
    public virtual string GetShipType()
    {
      return "SpaceShip";
    }
  }

  public class ApolloSpacecraft : SpaceShip
  {
    public virtual string GetShipType()
    {
      return "ApolloSpacecraft";
    }
  }

  public class Asteroid
  {
    public virtual void CollideWith(SpaceShip ship)
    {
      Console.WriteLine("Asteroid hit a SpaceShip");
    }
    public virtual void CollideWith(ApolloSpacecraft ship)
    {
      Console.WriteLine("Asteroid hit an ApolloSpacecraft");
    }
  };

  public class ExplodingAsteroid : Asteroid
  {
    public override void CollideWith(SpaceShip ship)
    {
      Console.WriteLine("ExplodingAsteroid hit a SpaceShip");
    }
    public override void CollideWith(ApolloSpacecraft ship)
    {
      Console.WriteLine("ExplodingAsteroid hit an ApolloSpacecraft");
    }
  };

  [TestFixture]
  public class Test
  {
    ApolloSpacecraft theApolloSpacecraft = new ApolloSpacecraft();
    SpaceShip theSpaceShip = new SpaceShip();

    Asteroid theAsteroid = new Asteroid();
    ExplodingAsteroid theExplodingAsteroid = new ExplodingAsteroid();      

    [Test]
    public void PrintShips()
    {
      Console.WriteLine(theApolloSpacecraft.GetShipType());
      Console.WriteLine(theSpaceShip.GetShipType());
    }

    [Test]
    public void PrintCollisions()
    {
      theAsteroid.CollideWith(theSpaceShip);
      theAsteroid.CollideWith(theApolloSpacecraft);
      theExplodingAsteroid.CollideWith(theSpaceShip);
      theExplodingAsteroid.CollideWith(theApolloSpacecraft);
    }

    [Test]
    public void DubbleDispatchProblem()
    {
      SpaceShip theApolloSpacecraft2 = new ApolloSpacecraft();

      theExplodingAsteroid.CollideWith(theApolloSpacecraft2);
    }
  }
}
