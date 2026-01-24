using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajesAPI.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("Getlist")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clienteRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _clienteRepository.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            return Ok(await _clienteRepository.Create(cliente));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Cliente cliente)
        {
            return Ok(await _clienteRepository.Update(cliente));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _clienteRepository.Delete(id));
        }
    }
}
