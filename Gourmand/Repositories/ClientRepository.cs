using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Gourmand.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly GourmandDBContext _db;
        public ClientRepository(GourmandDBContext db) => _db = db;
        
        public void AddClient(ClientDTO newClient)
        {
            var client = new Client
            {
                Name = newClient.Name,
                Username = newClient.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(newClient.Password),
                Email = newClient.Email,
                Number = newClient.Number,
                RegistrationDate = DateOnly.FromDateTime(DateTime.Now)
            };

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
            client.Password = BCrypt.Net.BCrypt.HashPassword(updatedClient.Password);
            client.Email = updatedClient.Email;
            client.Number = updatedClient.Number;
            _db.SaveChanges();
        }

        public int GenerateCode(Client client,EmailResetPasswordDTO resetPasswordData)
        {
            Random rnd = new Random();
            int code = RandomNumberGenerator.GetInt32(0, 1000000);

            client.ForgotPasswordCode = code;
            _db.SaveChanges();

            return code;
        }

        public void ForgotPassowrd(Client client, CodeResetPassordDTO resetPasswordData)
        {
            client.Password = BCrypt.Net.BCrypt.HashPassword(resetPasswordData.password);
            _db.SaveChanges();
        }
    }
}
