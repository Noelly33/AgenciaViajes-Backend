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
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResponse<List<ListarFacturaDTO>>> GetAll()
        {
            try
            {
                var facturas = await _context.Facturas
                    .Where(f => f.Estado == 1)
                    .Select(f => new ListarFacturaDTO
                    {
                        IdFactura = f.IdFactura,
                        NumeroFactura = f.NumeroFactura,
                        Cliente = f.Cliente.Nombres + " " + f.Cliente.Apellidos,
                        Ruta = f.Reserva.CiudadOrigen.Pais.Nombre + ", " + f.Reserva.CiudadOrigen.Nombre + " - " + f.Reserva.CiudadDestino.Pais.Nombre + ", " + f.Reserva.CiudadDestino.Nombre,
                        FechaEmision = f.FechaEmision,
                        MontoTotal = f.MontoTotal,
                        Activo = f.Estado == 1
                    })
                    .OrderByDescending(f => f.IdFactura)
                    .ToListAsync();

                return new JsonResponse<List<ListarFacturaDTO>>
                {
                    Success = true,
                    Message = "Facturas encontradas",
                    Data = facturas
                };
            }
            catch
            {
                return new JsonResponse<List<ListarFacturaDTO>>
                {
                    Success = false,
                    Message = "Error al obtener facturas"
                };
            }
        }

        public async Task<JsonResponse<FacturaDTO>> GetById(int id)
        {
            var factura = await _context.Facturas
                .Where(f => f.IdFactura == id && f.Estado == 1)
                .Select(f => new FacturaDTO
                {
                    IdFactura = f.IdFactura,
                    NumeroFactura = f.NumeroFactura,
                    IdCliente = f.IdCliente,
                    IdReserva = f.IdReserva,
                    IdMetodoPago = f.IdMetodoPago,
                    FechaEmision = f.FechaEmision,
                    MontoTotal = f.MontoTotal,
                    Activo = f.Estado == 1
                })
                .FirstOrDefaultAsync();

            if (factura == null)
            {
                return new JsonResponse<FacturaDTO>
                {
                    Success = false,
                    Message = "Factura no encontrada"
                };
            }

            return new JsonResponse<FacturaDTO>
            {
                Success = true,
                Message = "Factura encontrada",
                Data = factura
            };
        }

        public async Task<JsonResponse<bool>> Create(CreateFacturaDTO dto)
        {
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.IdReserva == dto.IdReserva && r.Estado == 1);

            if (reserva == null)
            {
                return new JsonResponse<bool>
                {
                    Success = false,
                    Message = "La reserva no existe o está inactiva"
                };
            }

            bool yaFacturada = await _context.Facturas
                .AnyAsync(f => f.IdReserva == dto.IdReserva && f.Estado == 1);

            if (yaFacturada)
            {
                return new JsonResponse<bool>
                {
                    Success = false,
                    Message = "Esta reserva ya tiene una factura asociada"
                };
            }

            var correlativo = await _context.Correlativos
                .FirstOrDefaultAsync(c => c.TipoDocumento == "FACTURA");

            if (correlativo == null)
            {
                return new JsonResponse<bool>
                {
                    Success = false,
                    Message = "No existe correlativo para FACTURA"
                };
            }

            correlativo.UltimoNumero++;

            decimal montoTotal = reserva.Precio;

            var factura = new Factura
            {
                NumeroFactura = correlativo.UltimoNumero.ToString("D6"),
                IdCliente = dto.IdCliente,
                IdReserva = dto.IdReserva,
                IdMetodoPago = dto.IdMetodoPago,
                MontoTotal = montoTotal,
                FechaEmision = DateTime.Now,
                Estado = 1,
                UsuarioRegistro = "SYSTEM",
                FechaRegistro = DateTime.Now
            };

            _context.Facturas.Add(factura);
            _context.Correlativos.Update(correlativo);

            await _context.SaveChangesAsync();

            return new JsonResponse<bool>
            {
                Success = true,
                Message = "Factura creada correctamente",
                Data = true
            };
        }


        public async Task<JsonResponse<FacturaDTO>> Update(FacturaDTO dto)
        {
            var factura = await _context.Facturas
                .FirstOrDefaultAsync(f => f.IdFactura == dto.IdFactura && f.Estado == 1);

            if (factura == null)
            {
                return new JsonResponse<FacturaDTO>
                {
                    Success = false,
                    Message = "Factura no encontrada"
                };
            }

            factura.IdCliente = dto.IdCliente;
            factura.IdReserva = dto.IdReserva;
            factura.IdMetodoPago = dto.IdMetodoPago;
            factura.FechaEmision = dto.FechaEmision;
            factura.MontoTotal = dto.MontoTotal;

            await _context.SaveChangesAsync();

            return new JsonResponse<FacturaDTO>
            {
                Success = true,
                Message = "Factura actualizada correctamente",
                Data = dto
            };
        }

        public async Task<JsonResponse<bool>> Delete(int id)
        {
            var factura = await _context.Facturas
                .FirstOrDefaultAsync(f => f.IdFactura == id && f.Estado == 1);

            if (factura == null)
            {
                return new JsonResponse<bool>
                {
                    Success = false,
                    Message = "Factura no encontrada"
                };
            }

            factura.Estado = 0;
            factura.UsuarioEliminacion = "SYSTEM";

            await _context.SaveChangesAsync();

            return new JsonResponse<bool>
            {
                Success = true,
                Message = "Factura eliminada correctamente",
                Data = true
            };
        }
    }
}
