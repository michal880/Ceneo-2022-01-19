using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace RoleObjectDesignPattern
{
  [TestFixture]
  public class RoleUsageTests
  {
    private IAnimalRepository _animalRepository = new AnimalRepository();

    [Test]
    public void Test()
    {
      Animal p = _animalRepository.Load(12);
      if (p.Can<Roar>())
      {
        var roar = p.Skill<Roar>();
        roar.MakeRoar();
      }
    }
  }
}