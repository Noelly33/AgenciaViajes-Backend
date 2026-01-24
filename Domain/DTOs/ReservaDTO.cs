using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }
        public string CodigoReserva { get; set; } = string.Empty;

        public int IdCliente { get; set; }

        public int IdTipoPasajero { get; set; }

        public int IdTipoPasaje { get; set; }

        public int IdCiudadOrigen { get; set; }

        public int IdCiudadDestino { get; set; }

        public DateTime FechaIda { get; set; }
        public DateTime? FechaVuelta { get; set; }

        public int CantidadPasajes { get; set; }
        public decimal Precio { get; set; }

        public bool Activo { get; set; }
    }

    
    public class ListarReservaDTO
    {
        public int IdReserva { get; set; }
        public string CodigoReserva { get; set; } = string.Empty;

        public string Cliente { get; set; } = string.Empty;

        public string Ruta { get; set; } = string.Empty;

        public DateTime FechaIda { get; set; }
        public DateTime? FechaVuelta { get; set; }

        public int CantidadPasajes { get; set; }
        public decimal Precio { get; set; }

        public bool Activo { get; set; }
    }
}
