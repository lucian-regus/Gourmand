using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        void UpdateClient(Client client, ClientDTO updatedClient);
        void DeleteClient(Client client);
    }
}
