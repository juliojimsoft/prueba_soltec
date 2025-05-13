using AutoMapper;
using prueba_soltec.DTOs.Usuarios;
using prueba_soltec.Models;

namespace prueba_soltec.Mappings
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuariosDto,Usuarios >();
            CreateMap<UsuariosActualizarDto, Usuarios>();
            CreateMap<UsuariosCrearDto, Usuarios>();
            CreateMap<Usuarios, UsuariosDto>();
            CreateMap<Usuarios, UsuariosActualizarDto>();
            CreateMap<Usuarios, UsuariosCrearDto>();

        }
    }
}
