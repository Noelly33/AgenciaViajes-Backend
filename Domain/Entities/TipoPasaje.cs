using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoPasaje : AuditableEntity
    {
        [Key]
        public int IdTipoPasaje { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; } = string.Empty;

    }
}
