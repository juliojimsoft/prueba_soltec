using Microsoft.EntityFrameworkCore;
using prueba_soltec.Data;
using prueba_soltec.DTOs;
using prueba_soltec.Interfaces;
using prueba_soltec.Models;

namespace prueba_soltec.Repositories
{
    public class UsuariosRepository :IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuariosRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuarios>> ObtenerTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuarios?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuarios?> ObtenerPorEmail(string email)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u=>u.Email==email);
        }
        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Email == email);
        }

        public async Task AgregarAsync(Usuarios usuarios)
        {
            await _context.Usuarios.AddAsync(usuarios);
            await _context.SaveChangesAsync(); 
        }

        public async Task ActualizarAsync(Usuarios usuario)
        {
            _context.Entry(usuario).State=EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task EliminarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExisteAsync(int id)
        {
            return await _context.Usuarios.AnyAsync(p => p.Id == id);
        }
    }
}
