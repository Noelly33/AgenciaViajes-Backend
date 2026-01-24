using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        // Relación con País
        public int IdPais { get; set; }
        public Pais Pais { get; set; } = null!;
    }
}
