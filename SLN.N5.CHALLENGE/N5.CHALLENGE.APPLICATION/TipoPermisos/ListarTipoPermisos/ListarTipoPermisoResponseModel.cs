using N5.CHALLENGE.DOMAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.APPLICATION.TipoPermisos.ListarTipoPermisos
{
    public class ListarTipoPermisoResponseModel
    {
        public ListarTipoPermisoResponseModel()
        {
            TipoPermisos = new();
        }

        public List<TipoPermisoInfoDTO> TipoPermisos { get; set; }
        public string? mensajeError { get; set; }
    }
}
