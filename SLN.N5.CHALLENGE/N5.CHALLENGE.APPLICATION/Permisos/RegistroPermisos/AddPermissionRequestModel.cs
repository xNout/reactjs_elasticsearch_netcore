using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos
{
    public record AddPermissionRequestModel : IRequest<AddPermissionResponseModel>
    {
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}
