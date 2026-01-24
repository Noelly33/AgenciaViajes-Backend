using Domain.Common;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReservaRepository
    {
        Task<JsonResponse<List<ListarReservaDTO>>> GetAll();
        Task<JsonResponse<ReservaDTO>> GetById(int id);
        Task<JsonResponse<ReservaDTO>> Create(ReservaDTO reserva);
        Task<JsonResponse<ReservaDTO>> Update(ReservaDTO reserva);
        Task<JsonResponse<bool>> Delete(int id);
    }
}
