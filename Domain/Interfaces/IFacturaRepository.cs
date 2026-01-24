using Domain.Common;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFacturaRepository
    {
        Task<JsonResponse<List<ListarFacturaDTO>>> GetAll();
        Task<JsonResponse<FacturaDTO>> GetById(int id);
        Task<JsonResponse<bool>> Create(CreateFacturaDTO factura);
        Task<JsonResponse<FacturaDTO>> Update(FacturaDTO factura);
        Task<JsonResponse<bool>> Delete(int id);
    }
}

