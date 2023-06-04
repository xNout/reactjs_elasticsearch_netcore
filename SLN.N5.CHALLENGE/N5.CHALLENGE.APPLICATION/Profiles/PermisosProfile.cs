using AutoMapper;
using N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos;
using N5.CHALLENGE.DOMAIN.DTOs;
using N5.CHALLENGE.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.APPLICATION.Profiles
{
    public class PermisosProfile : Profile
    {
        public PermisosProfile()
        {
            CreateMap<Permiso, PermissionDTO>()
                .ForMember( x => x.IdTipoPermiso, y => y.MapFrom(m => m.TipoPermiso));

            CreateMap<PermissionInfoModel, Permiso>();
            CreateMap<TipoPermiso, TipoPermisoInfoDTO>();

            CreateMap<AddPermissionRequestModel, PermissionInfoModel> ();
            CreateMap<ModifyPermissionRequestModel, PermissionInfoModel>();
            CreateMap<PermissionInfoModel, PermissionDTO>()
                .ForMember(x => x.IdTipoPermiso, y => y.MapFrom(m => m.TipoPermiso));
        }

        
    }
}
