using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{

    public class CreateFacturaDTO
    {
        public int IdCliente { get; set; }
        public int IdReserva { get; set; }
        public int IdMetodoPago { get; set; }
    }

    public class FacturaDTO
    {
        public int IdFactura { get; set; }
        public string NumeroFactura { get; set; } = string.Empty;
        public int IdCliente { get; set; }
        public int IdReserva { get; set; }
        public int IdMetodoPago { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Activo { get; set; }
    }

    public class ListarFacturaDTO
    {
        public int IdFactura { get; set; }
        public string NumeroFactura { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Ruta { get; set; } = string.Empty;
        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Activo { get; set; }
    }
}
