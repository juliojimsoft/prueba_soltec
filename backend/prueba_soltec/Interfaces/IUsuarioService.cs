using prueba_soltec.DTOs.Usuarios;

namespace prueba_soltec.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuariosDto>> ObtenerTodosUsuariosAsync();
        Task<UsuariosDto> ObtenerUsuariosPorIdAsync(int id);
        Task<UsuariosDto> CrearUsuarioAsync(UsuariosCrearDto usuariosCrearDto);
        Task<UsuariosDto> ActualizarUsuarioAsync(int id, UsuariosActualizarDto usuariosActualizarDto);
        Task EliminarUsuarioAsync(int id);
    }
}
