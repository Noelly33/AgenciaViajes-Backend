using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.DTOs;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly ApplicationDbContext _context;

        public CatalogoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResponse<List<CatalogoDTO>>> GetCiudades()
        {
            try
            {

                var lista = await _context.Ciudades
                    .Include(c => c.Pais)
                    .Select(c => new CatalogoDTO
                    {
                        Id = c.IdCiudad,
                        Nombre = c.Pais.Nombre + " - " + c.Nombre
                    })
                    .ToListAsync();

                return new JsonResponse<List<CatalogoDTO>> { Success = true, Data = lista };
            }
            catch (Exception ex)
            {
                return new JsonResponse<List<CatalogoDTO>> { Success = false, Message = "Error: " + ex.Message };
            }
        }

        public async Task<JsonResponse<List<CatalogoDTO>>> GetTiposPasajero()
        {
            var lista = await _context.TiposPasajero
                .Select(t => new CatalogoDTO { Id = t.IdTipoPasajero, Nombre = t.Nombre })
                .ToListAsync();
            return new JsonResponse<List<CatalogoDTO>> { Success = true, Data = lista };
        }

        public async Task<JsonResponse<List<CatalogoDTO>>> GetTiposPasaje()
        {
            var lista = await _context.TiposPasaje
                .Select(t => new CatalogoDTO { Id = t.IdTipoPasaje, Nombre = t.Nombre })
                .ToListAsync();
            return new JsonResponse<List<CatalogoDTO>> { Success = true, Data = lista };
        }
    }
}