using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos
{
    public record AddPermissionResponseModel
    {
        public int Id { get; set; }
        public string? mensajeError { get; set; }
    }
}
