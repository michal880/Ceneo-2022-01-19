namespace RoleObjectDesignPattern
{
  internal class AnimalRepository : IAnimalRepository
  {
    public Animal Load(int userId)
    {
      //if ("Lion")
      {
        return new Lion();
      }
    }
  }
}