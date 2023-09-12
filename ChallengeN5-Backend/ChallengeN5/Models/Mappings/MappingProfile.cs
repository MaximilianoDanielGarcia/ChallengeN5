using AutoMapper;
using ChallengeN5.Models.DTOs;

namespace ChallengeN5.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PermisoDTO, Permiso>()
                .ForMember(p => p.TipoPermiso, d => d.MapFrom(x => x.TipoPermisoId))
                .ForMember(p => p.TipoPermisoNavigation, d => d.Ignore());

            CreateMap<Permiso, PermisoDTO>()
                .ForMember(s => s.TipoPermisoId, d => d.MapFrom(x => x.TipoPermiso));

            CreateMap<TipoPermisoDTO, TipoPermiso>()
                .ForMember(t => t.Permisos, d => d.Ignore());

            CreateMap<TipoPermiso, TipoPermisoDTO>();
        }
    }
}
