using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViajesAPI.Controllers
{
    [ApiController]
    [Route("api/catalogos")]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public CatalogoController(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        [HttpGet("ciudades")]
        public async Task<IActionResult> GetCiudades()
        {
            return Ok(await _catalogoRepository.GetCiudades());
        }

        [HttpGet("tipos-pasajero")]
        public async Task<IActionResult> GetTiposPasajero()
        {
            return Ok(await _catalogoRepository.GetTiposPasajero());
        }

        [HttpGet("tipos-pasaje")]
        public async Task<IActionResult> GetTiposPasaje()
        {
            return Ok(await _catalogoRepository.GetTiposPasaje());
        }
    }
}