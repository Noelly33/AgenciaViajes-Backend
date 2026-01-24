using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Factura : AuditableEntity
    {
        [Key]
        public int IdFactura { get; set; }

        [MaxLength(10)]
        public string NumeroFactura { get; set; } = string.Empty;

        // ===== RELACIÓN CON CLIENTE =====
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

        // ===== RELACIÓN CON RESERVA =====
        public int IdReserva { get; set; }
        public Reserva Reserva { get; set; } = null!;

        public DateTime FechaEmision { get; set; }

        // ===== RELACIÓN CON METODO DE PAGO =====
        public int IdMetodoPago { get; set; }
        public MetodoPago MetodoPago { get; set; } = null!;

        [Column(TypeName = "decimal(10,2)")]
        public decimal MontoTotal { get; set; }
    }
}
