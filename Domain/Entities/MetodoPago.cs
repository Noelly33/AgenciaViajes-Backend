using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MetodoPago : AuditableEntity
    {
        [Key]
        public int IdMetodoPago { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; } = string.Empty;

    }
}
