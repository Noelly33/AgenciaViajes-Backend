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
    public class Reserva : AuditableEntity
    {
        [Key]
        public int IdReserva { get; set; }

        [MaxLength(10)]
        public string CodigoReserva { get; set; } = string.Empty;

        // ===== RELACIÓN CON CLIENTE =====
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

        // ===== RELACIÓN CON TIPO PASAJERO =====
        public int IdTipoPasajero { get; set; }
        public TipoPasajero TipoPasajero { get; set; } = null!;

        // ===== RELACIÓN CON TIPO PASAJE =====
        public int IdTipoPasaje { get; set; }
        public TipoPasaje TipoPasaje { get; set; } = null!;

        // ===== RELACIÓN CON CIUDAD =====
        public int IdCiudadOrigen { get; set; }
        public Ciudad CiudadOrigen { get; set; } = null!;

        public int IdCiudadDestino { get; set; }
        public Ciudad CiudadDestino { get; set; } = null!;

        public DateTime FechaIda { get; set; }
        public DateTime? FechaVuelta { get; set; }

        public int CantidadPasajes { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Precio { get; set; }
    }
}
