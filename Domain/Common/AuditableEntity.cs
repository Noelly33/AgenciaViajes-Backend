using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public int Estado { get; set; }          
        public string? UsuarioRegistro { get; set; }
        public string? UsuarioEliminacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

}
