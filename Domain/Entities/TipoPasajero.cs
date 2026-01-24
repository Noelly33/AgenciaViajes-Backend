using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoPasajero
    {
        [Key]
        public int IdTipoPasajero { get; set; }

        [MaxLength(20)]
        public string Nombre { get; set; } = string.Empty; // Adulto, Joven, Niño, Bebé
    }
}
