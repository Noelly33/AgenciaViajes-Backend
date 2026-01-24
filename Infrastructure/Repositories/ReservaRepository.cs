using Domain.Common;
using Domain.DTOs;
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
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

 
        public async Task<JsonResponse<List<ListarReservaDTO>>> GetAll()
        {
            try
            {
                var reservas = await _context.Reservas
                    .Where(r => r.Estado == 1)
                    .Select(r => new ListarReservaDTO
                    {
                        IdReserva = r.IdReserva,
                        CodigoReserva = r.CodigoReserva,
                        Cliente = r.Cliente.Nombres + " " + r.Cliente.Apellidos,
                        Ruta = r.CiudadOrigen.Pais.Nombre + ", " + r.CiudadOrigen.Nombre + " - " + r.CiudadDestino.Pais.Nombre + ", " + r.CiudadDestino.Nombre,
                        FechaIda = r.FechaIda,
                        FechaVuelta = r.FechaVuelta,
                        CantidadPasajes = r.CantidadPasajes,
                        Precio = r.Precio,
                        Activo = r.Estado == 1
                    })
                    .OrderByDescending(r => r.IdReserva)
                    .ToListAsync();

                return new JsonResponse<List<ListarReservaDTO>>
                {
                    Success = true,
                    Message = "Reservas encontradas",
                    Data = reservas
                };
            }
            catch
            {
                return new JsonResponse<List<ListarReservaDTO>>
                {
                    Success = false,
                    Message = "Error al obtener reservas"
                };
            }
        }

        public async Task<JsonResponse<ReservaDTO>> GetById(int id)
        {
            var reserva = await _context.Reservas
                .Where(r => r.IdReserva == id && r.Estado == 1)
                .Select(r => new ReservaDTO
                {
                    IdReserva = r.IdReserva,
                    CodigoReserva = r.CodigoReserva,
                    IdCliente = r.IdCliente,
                    IdTipoPasajero = r.IdTipoPasajero,
                    IdTipoPasaje = r.IdTipoPasaje,
                    IdCiudadOrigen = r.IdCiudadOrigen,
                    IdCiudadDestino = r.IdCiudadDestino,
                    FechaIda = r.FechaIda,
                    FechaVuelta = r.FechaVuelta,
                    CantidadPasajes = r.CantidadPasajes,
                    Precio = r.Precio,
                    Activo = r.Estado == 1
                })
                .FirstOrDefaultAsync();

            if (reserva == null)
            {
                return new JsonResponse<ReservaDTO>
                {
                    Success = false,
                    Message = "Reserva no encontrada"
                };
            }

            return new JsonResponse<ReservaDTO>
            {
                Success = true,
                Message = "Reserva encontrada",
                Data = reserva
            };
        }

        public async Task<JsonResponse<ReservaDTO>> Create(ReservaDTO dto)
        {
            var reserva = new Reserva
            {
                CodigoReserva = dto.CodigoReserva,
                IdCliente = dto.IdCliente,
                IdTipoPasajero = dto.IdTipoPasajero,
                IdTipoPasaje = dto.IdTipoPasaje,
                IdCiudadOrigen = dto.IdCiudadOrigen,
                IdCiudadDestino = dto.IdCiudadDestino,
                FechaIda = dto.FechaIda,
                FechaVuelta = dto.FechaVuelta,
                CantidadPasajes = dto.CantidadPasajes,
                Precio = dto.Precio,
                Estado = 1,
                UsuarioRegistro = "SYSTEM",
                FechaRegistro = DateTime.Now
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            dto.IdReserva = reserva.IdReserva;
            dto.Activo = true;

            return new JsonResponse<ReservaDTO>
            {
                Success = true,
                Message = "Reserva creada correctamente",
                Data = dto
            };
        }


        public async Task<JsonResponse<ReservaDTO>> Update(ReservaDTO dto)
        {
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.IdReserva == dto.IdReserva && r.Estado == 1);

            if (reserva == null)
            {
                return new JsonResponse<ReservaDTO>
                {
                    Success = false,
                    Message = "Reserva no encontrada"
                };
            }

            reserva.IdCliente = dto.IdCliente;
            reserva.IdTipoPasajero = dto.IdTipoPasajero;
            reserva.IdTipoPasaje = dto.IdTipoPasaje;
            reserva.IdCiudadOrigen = dto.IdCiudadOrigen;
            reserva.IdCiudadDestino = dto.IdCiudadDestino;
            reserva.FechaIda = dto.FechaIda;
            reserva.FechaVuelta = dto.FechaVuelta;
            reserva.CantidadPasajes = dto.CantidadPasajes;
            reserva.Precio = dto.Precio;

            await _context.SaveChangesAsync();

            return new JsonResponse<ReservaDTO>
            {
                Success = true,
                Message = "Reserva actualizada correctamente",
                Data = dto
            };
        }

        public async Task<JsonResponse<bool>> Delete(int id)
        {
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.IdReserva == id && r.Estado == 1);

            if (reserva == null)
            {
                return new JsonResponse<bool>
                {
                    Success = false,
                    Message = "Reserva no encontrada"
                };
            }

            reserva.Estado = 0;
            reserva.UsuarioEliminacion = "SYSTEM"; 

            await _context.SaveChangesAsync();

            return new JsonResponse<bool>
            {
                Success = true,
                Message = "Reserva eliminada correctamente",
                Data = true
            };
        }

    }
}
