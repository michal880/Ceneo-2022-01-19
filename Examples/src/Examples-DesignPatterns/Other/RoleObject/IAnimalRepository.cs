namespace RoleObjectDesignPattern
{
  internal interface IAnimalRepository
  {
    Animal Load(int userId);
  }
}