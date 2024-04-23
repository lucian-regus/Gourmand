using Gourmand.DTO;
using Gourmand.Filters.ClientFilters;
using Gourmand.Models;
using Gourmand.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Gourmand.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository) => _clientRepository = clientRepository;

        [HttpGet("{ID}")]
        [TypeFilter(typeof(EnsureIDExists))]
        public IActionResult GetClient(int ID)
        {
            var client = HttpContext.Items["Client"] as Client;

            return Ok(new
            {
                client.Name,
                client.Email,
                client.Number
            });
        }

        [HttpPost]
        [TypeFilter(typeof(EnsureNewClient))]
        public IActionResult AddClient([FromBody]ClientDTO client)
        {
            var newClient = new Client{
                 Name = client.Name,
                 Username = client.Username,
                 Password = client.Password,
                 Email = client.Email,
                 Number = client.Number,
                 RegistrationDate = DateOnly.FromDateTime(DateTime.Now)
            };

            _clientRepository.AddClient(newClient);

            return Ok(client);
        }

        [HttpPut("{ID}")]
        [TypeFilter(typeof(EnsureIDExists))]
        public IActionResult UpdateClient(int id,[FromBody] ClientDTO client)
        {
            _clientRepository.UpdateClient(HttpContext.Items["Client"] as Client,client);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        [TypeFilter(typeof(EnsureIDExists))]
        public IActionResult DeleteClient(int ID)
        {
            _clientRepository.DeleteClient(HttpContext.Items["Client"] as Client);
            return Ok();
        }
    }
}
