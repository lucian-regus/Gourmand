using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public interface IClientRepository
    {
        void AddClient(ClientDTO client);
        void UpdateClient(Client client, ClientDTO updatedClient);
        void DeleteClient(Client client);
        void ForgotPassowrd(Client client,CodeResetPassordDTO resetPasswordData);
        int GenerateCode(Client client, EmailResetPasswordDTO resetPasswordData);
    }
}
