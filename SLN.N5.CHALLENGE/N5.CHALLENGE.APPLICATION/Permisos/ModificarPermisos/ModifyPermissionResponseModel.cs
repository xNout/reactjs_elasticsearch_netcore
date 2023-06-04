using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos
{
    public record ModifyPermissionResponseModel
    {
        public bool wasModified { get; set; }
        public string? mensajeError { get; set; }
    }
}
