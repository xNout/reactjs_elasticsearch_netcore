using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.DOMAIN.DTOs
{
    public record PermissionInfoModel
    {
        public PermissionInfoModel(string nombreEmpleado, string apellidoEmpleado, int tipoPermiso, DateTime fechaPermiso)
        {
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado = apellidoEmpleado;
            TipoPermiso = tipoPermiso;
            FechaPermiso = fechaPermiso;
        }

        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }

    }
}
