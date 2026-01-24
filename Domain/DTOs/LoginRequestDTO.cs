using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class LoginRequestDto
    {
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
    }

}
