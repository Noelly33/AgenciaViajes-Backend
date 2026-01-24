using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : AuditableEntity
    {
        [Key]
        public int IdCliente { get; set; }

        [MaxLength(50)]
        public string Nombres { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [MaxLength(15)]
        public string Cedula { get; set; } = string.Empty;

        [MaxLength(15)]
        public string Telefono { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Correo { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Direccion { get; set; } = string.Empty;
    }
}
