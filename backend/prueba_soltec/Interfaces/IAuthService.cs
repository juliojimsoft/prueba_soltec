namespace prueba_soltec.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string correo, string contrasenia);
    }
}
