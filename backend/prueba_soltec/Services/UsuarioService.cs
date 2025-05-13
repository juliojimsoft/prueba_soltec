using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using prueba_soltec.Interfaces;
using prueba_soltec.Models;
using prueba_soltec.Helpers;
using prueba_soltec.DTOs.Usuarios;

namespace prueba_soltec.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuariosDto>> ObtenerTodosUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.ObtenerTodosAsync();
            return _mapper.Map<IEnumerable<UsuariosDto>>(usuarios);
        }
        public async Task<UsuariosDto> ObtenerUsuariosPorIdAsync(int id)
        {
            var usuarios = await _usuarioRepository.ObtenerPorIdAsync(id);
            if (usuarios == null) throw new KeyNotFoundException("Producto no encontrado");
            return _mapper.Map<UsuariosDto>(usuarios);
        }
        public async Task<UsuariosDto> CrearUsuarioAsync(UsuariosCrearDto usuariosCrearDto)
        {

            if(await _usuarioRepository.ExisteEmailAsync(usuariosCrearDto.Email))
            {
                throw new InvalidOperationException("El correo ya está registrado");
            }

            var usuario = new Usuarios
            {
                Nombre = usuariosCrearDto.Nombre,
                PrimerApellido = usuariosCrearDto.PrimerApellido,
                SegundoApellido = usuariosCrearDto.SegundoApellido,
                Email = usuariosCrearDto.Email,
                Contrasenia = PasswordHasher.Hash(usuariosCrearDto.Contrasenia),
                Activo=usuariosCrearDto.Activo
            };
            await _usuarioRepository.AgregarAsync(usuario);
            return _mapper.Map<UsuariosDto>(usuario);
        }
        
        public async Task<UsuariosDto> ActualizarUsuarioAsync(int id, UsuariosActualizarDto usuariosActualizar)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);
            if (usuario == null) throw new KeyNotFoundException("Producto no encontrado");
            _mapper.Map(usuariosActualizar, usuario);
            await _usuarioRepository.ActualizarAsync(usuario);
            
            var usuarioActualizado = await _usuarioRepository.ObtenerPorIdAsync(id);
            return _mapper.Map<UsuariosDto>(usuarioActualizado);
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            if (!await _usuarioRepository.ExisteAsync(id))
                throw new KeyNotFoundException("Producto no encontrado");
            await _usuarioRepository.EliminarAsync(id);
        }
    }
}
