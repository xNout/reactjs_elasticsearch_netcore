using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N5.CHALLENGE.DOMAIN.DTOs;
using N5.CHALLENGE.DOMAIN.Entities;
using N5.CHALLENGE.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.INFRA.REPOSITORY.Services
{
    public class PermisosRepositorio : GenericRepositorio<Permiso>, IPermisosRepositorio
    {
        private readonly IMapper _mapper;
        public PermisosRepositorio(N5NowEFContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<List<PermissionDTO>> GetAll()
        {
            return await (from permisos in context.Permisos.AsNoTracking()
                          join permisoTipo in context.TipoPermisos.AsNoTracking()
                          on permisos.TipoPermiso equals permisoTipo.Id
                          select Mapear(_mapper.Map<PermissionDTO>(permisos), permisoTipo)
                          ).ToListAsync();
        }
        private static PermissionDTO Mapear(PermissionDTO Model, TipoPermiso tipo)
        {
            Model.DescripcionPermiso = tipo.Descripcion;
            return Model;
        }
        public async Task<bool> Modify(int Id, PermissionInfoModel Model)
        {
            Permiso? permiso = await Entity.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (permiso is null)
                return false;

            permiso.NombreEmpleado = Model.NombreEmpleado;
            permiso.ApellidoEmpleado = Model.ApellidoEmpleado;
            permiso.FechaPermiso = Model.FechaPermiso;
            permiso.TipoPermiso = Model.TipoPermiso;

            Entity.Update(permiso);

            return await SaveChangesAsync();
        }
        public async Task<int> Create(PermissionInfoModel Model)
        {
            Permiso permiso = _mapper.Map<Permiso>(Model);

            await Entity.AddAsync(permiso);
            await SaveChangesAsync();
            
            return permiso.Id;
        }
    }
}
