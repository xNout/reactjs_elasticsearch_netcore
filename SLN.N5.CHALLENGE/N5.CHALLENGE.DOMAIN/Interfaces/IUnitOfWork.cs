using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.DOMAIN.Interfaces
{
    public interface IUnitOfWork
    {
        IPermisosRepositorio permisosRepositorio { get; }
        ITipoPermisosRepositorio tipoPermisosRepositorio { get; }
    }
}
