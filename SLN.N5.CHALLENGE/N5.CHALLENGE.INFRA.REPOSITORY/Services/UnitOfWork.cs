using AutoMapper;
using N5.CHALLENGE.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.INFRA.REPOSITORY.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly N5NowEFContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(N5NowEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IPermisosRepositorio? _permisosRepositorio;
        private ITipoPermisosRepositorio? _tipoPermisosRepositorio;


        public IPermisosRepositorio permisosRepositorio
        {
            get
            {
                if (_permisosRepositorio is null)
                    _permisosRepositorio = new PermisosRepositorio(_context, _mapper);

                return _permisosRepositorio;
            }
        }
        public ITipoPermisosRepositorio tipoPermisosRepositorio
        {
            get
            {
                if (_tipoPermisosRepositorio is null)
                    _tipoPermisosRepositorio = new TipoPermisosRepositorio(_context, _mapper);

                return _tipoPermisosRepositorio;
            }
        }
    }
}
