using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pais
    {
        [Key]
        public int IdPais { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        // 🔹 Relación con Ciudad
        public ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();

    }
}
