using Gourmand.DTO;
using Gourmand.Filters.ClientFilters;
using Gourmand.Models;
using Gourmand.Repositories;
using Gourmand.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly ITokenService _tokenService;

        public ClientController(IClientRepository clientRepository, ITokenService tokenService)
        {
            _clientRepository = clientRepository;
            _tokenService = tokenService;
        }
        [HttpGet("{ID}")]
        [TypeFilter(typeof(EnsureIDExists))]
        public IActionResult GetClientById(int ID)
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
        public IActionResult register([FromBody]ClientDTO newClient)
        {

            _clientRepository.AddClient(newClient);

            return Ok();
        }

        [HttpPut("{ID}")]
        [TypeFilter(typeof(EnsureIDExists))]
        [Authorize]
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

        [HttpPost("login")]
        [TypeFilter(typeof(EnsureClientExists))]
        public IActionResult Login([FromBody] LoginDTO loginData)
        {
            return Ok(_tokenService.GenerateToken(loginData.username));
        }

        [HttpPut("generateCode")]
        [TypeFilter(typeof(EnsureEmailExists))]
        public IActionResult GenerateForgotPasswordCode([FromBody]EmailResetPasswordDTO resetPasswordData)
        {
            return Ok(_clientRepository.GenerateCode(HttpContext.Items["Client"] as Client,resetPasswordData));
        }

        
        [HttpPut("resetPassword")]
        [TypeFilter(typeof(EnsureCodeExists))]
        public IActionResult forgotPassword([FromBody]CodeResetPassordDTO resetPasswordData) 
        {
            _clientRepository.ForgotPassowrd(HttpContext.Items["Client"] as Client, resetPasswordData);

            return Ok();
        }
        
    }
}
