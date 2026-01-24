using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;   
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResponse<Usuario>> Login(string correo, string clave)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .Where(u =>
                        u.Correo == correo &&
                        u.Clave == clave &&
                        u.Estado == 1)
                    .FirstOrDefaultAsync();

                if (usuario == null)
                {
                    return new JsonResponse<Usuario>
                    {
                        Success = false,
                        Message = "Correo o clave incorrectos"
                    };
                }

                return new JsonResponse<Usuario>
                {
                    Success = true,
                    Message = "Inicio de sesión exitoso",
                    Data = usuario
                };
            }
            catch (Exception)
            {
                return new JsonResponse<Usuario>
                {
                    Success = false,
                    Message = "Error al iniciar sesión"
                };
            }
        }
    }
}
