using Microsoft.AspNetCore.Mvc;
using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Controllers.v1
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertClient([FromBody] Client client)
        {

            await _clientRepository.Insert(client);
            return new CreatedResult(nameof(GetClientByCpf), new { client.Cpf });
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetClientByCpf(long cpf)
        {
            var client = await _clientRepository.GetClientByCpf(cpf);
            return Ok(client);
        }
    }
}
