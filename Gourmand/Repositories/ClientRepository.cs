using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;
using Microsoft.EntityFrameworkCore;

namespace Gourmand.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly GourmandDBContext _db;
        public ClientRepository(GourmandDBContext db) => _db = db;
        
        public void AddClient(Client client)
        {
            _db.Client.Add(client);
            _db.SaveChanges();
        }

        public void DeleteClient(Client client)
        {
            client.IsDeleted = true;
            _db.SaveChanges();
        }

        public void UpdateClient(Client client, ClientDTO updatedClient)
        {
            client.Name = updatedClient.Name;
            client.Username = updatedClient.Username;
            client.Password = updatedClient.Password;
            client.Email = updatedClient.Email;
            client.Number = updatedClient.Number;
            _db.SaveChanges();
        }
    }
}
