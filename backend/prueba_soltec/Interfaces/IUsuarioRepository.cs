using prueba_soltec.Models;

namespace prueba_soltec.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuarios>> ObtenerTodosAsync();
        Task<Usuarios> ObtenerPorIdAsync(int id);

        Task<Usuarios> ObtenerPorEmail(string email);
        Task<bool> ExisteEmailAsync(string email);
        Task AgregarAsync(Usuarios usuarios);
        Task ActualizarAsync(Usuarios usuarios);
        Task EliminarAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}
