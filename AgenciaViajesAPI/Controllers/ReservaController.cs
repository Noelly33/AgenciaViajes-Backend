using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajesAPI.Controllers
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [HttpGet("Getlist")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reservaRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _reservaRepository.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ReservaDTO reserva)
        {
            return Ok(await _reservaRepository.Create(reserva));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ReservaDTO reserva)
        {
            return Ok(await _reservaRepository.Update(reserva));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _reservaRepository.Delete(id);
            return Ok(response);
        }

    }
}
