using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common; 
using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface ICatalogoRepository
    {
        Task<JsonResponse<List<CatalogoDTO>>> GetCiudades();
        Task<JsonResponse<List<CatalogoDTO>>> GetTiposPasajero();
        Task<JsonResponse<List<CatalogoDTO>>> GetTiposPasaje();
    }
}