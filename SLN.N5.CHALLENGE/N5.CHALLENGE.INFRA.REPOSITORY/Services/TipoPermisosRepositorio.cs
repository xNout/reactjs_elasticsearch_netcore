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
    public class TipoPermisosRepositorio : GenericRepositorio<TipoPermiso>, ITipoPermisosRepositorio
    {
        private readonly IMapper _mapper;
        public TipoPermisosRepositorio(N5NowEFContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<string?> GetDescription(int Id)
        {
            return await Entity.AsNoTracking().Where(x => x.Id == Id).Select(x => x.Descripcion).FirstOrDefaultAsync();
        }

        public async Task<List<TipoPermisoInfoDTO>> GetAll()
        {
            return await Entity.AsNoTracking().Select(x => _mapper.Map<TipoPermisoInfoDTO>(x)).ToListAsync();
        }
    }
}
