using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResponse<List<Cliente>>> GetAll()
        {
            try
            {
                var clientes = await _context.Clientes
                    .Where(c => c.Estado == 1)
                    .OrderByDescending(c => c.IdCliente)
                    .ToListAsync();

                return new JsonResponse<List<Cliente>>
                {
                    Success = true,
                    Message = "Clientes encontrados",
                    Data = clientes
                };
            }
            catch
            {
                return new JsonResponse<List<Cliente>>
                {
                    Success = false,
                    Message = "Error al obtener clientes"
                };
            }
        }

        public async Task<JsonResponse<Cliente>> GetById(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.IdCliente == id && c.Estado == 1);

            if (cliente == null)
            {
                return new JsonResponse<Cliente>
                {
                    Success = false,
                    Message = "Cliente no encontrado"
                };
            }

            return new JsonResponse<Cliente>
            {
                Success = true,
                Message = "Cliente encontrado",
                Data = cliente
            };
        }

        public async Task<JsonResponse<Cliente>> Create(Cliente cliente)
        {
            bool existeCedula = await _context.Clientes
                .AnyAsync(c => c.Cedula == cliente.Cedula && c.Estado == 1);

            if (existeCedula)
            {
                return new JsonResponse<Cliente>
                {
                    Success = false,
                    Message = "La cédula ya existe"
                };
            }

            cliente.Estado = 1;
            cliente.FechaRegistro = DateTime.Now;
            cliente.UsuarioRegistro = "SYSTEM";
            cliente.UsuarioEliminacion = null;

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return new JsonResponse<Cliente>
            {
                Success = true,
                Message = "Cliente creado correctamente",
                Data = cliente
            };
        }

        public async Task<JsonResponse<Cliente>> Update(Cliente cliente)
        {
            var clienteDb = await _context.Clientes
                .FirstOrDefaultAsync(c => c.IdCliente == cliente.IdCliente && c.Estado == 1);

            if (clienteDb == null)
            {
                return new JsonResponse<Cliente>
                {
                    Success = false,
                    Message = "Cliente no encontrado"
                };
            }

            clienteDb.Nombres = cliente.Nombres;
            clienteDb.Apellidos = cliente.Apellidos;
            clienteDb.Cedula = cliente.Cedula;
            clienteDb.Telefono = cliente.Telefono;
            clienteDb.Correo = cliente.Correo;
            clienteDb.Direccion = cliente.Direccion;

            await _context.SaveChangesAsync();

            return new JsonResponse<Cliente>
            {
                Success = true,
                Message = "Cliente actualizado correctamente",
                Data = clienteDb
            };
        }

        public async Task<JsonResponse<Cliente>> Delete(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.IdCliente == id && c.Estado == 1);

            if (cliente == null)
            {
                return new JsonResponse<Cliente>
                {
                    Success = false,
                    Message = "Cliente no encontrado"
                };
            }

            cliente.Estado = 0;
            cliente.UsuarioEliminacion = "SYSTEM";

            await _context.SaveChangesAsync();

            return new JsonResponse<Cliente>
            {
                Success = true,
                Message = "Cliente eliminado correctamente"
            };
        }
    }
}
