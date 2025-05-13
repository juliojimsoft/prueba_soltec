using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using prueba_soltec.Helpers;
using prueba_soltec.Interfaces;

namespace prueba_soltec.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _config;
        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration config)
        {
            _usuarioRepository= usuarioRepository;
            _config = config;
        }
        public async Task<string> LoginAsync(string correo, string contrasenia)
        {
            var usuario = await _usuarioRepository.ObtenerPorEmail(correo);
            
            if (usuario == null|| !PasswordHasher.Verify(contrasenia, usuario.Contrasenia))
            {
                throw new UnauthorizedAccessException("Credenciales inválidas");
            }
            return GenerarToken(usuario.Email);    
        }

        private string GenerarToken(string correo)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, correo)
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
