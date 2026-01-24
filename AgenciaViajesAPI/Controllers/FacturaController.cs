using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajesAPI.Controllers
{
    [ApiController]
    [Route("api/facturas")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaController(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        [HttpGet("Getlist")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _facturaRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _facturaRepository.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateFacturaDTO factura)
        {
            return Ok(await _facturaRepository.Create(factura));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] FacturaDTO factura)
        {
            return Ok(await _facturaRepository.Update(factura));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _facturaRepository.Delete(id);
            return Ok(response);
        }

    }
}
