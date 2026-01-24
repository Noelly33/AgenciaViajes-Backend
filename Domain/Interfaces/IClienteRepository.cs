using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<JsonResponse<List<Cliente>>> GetAll();
        Task<JsonResponse<Cliente>> GetById(int id);
        Task<JsonResponse<Cliente>> Create(Cliente cliente);
        Task<JsonResponse<Cliente>> Update(Cliente cliente);
        Task<JsonResponse<Cliente>> Delete(int id); 
    }
}
