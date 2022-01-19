namespace AspMvc.Examples.Common.Client.Command
{
  public interface IClientCommandRepository
  {
    Client Get(int id);
    void Update(Client client);
    void Add(Client client);
    bool ClientExist(string taxId);
  }
}