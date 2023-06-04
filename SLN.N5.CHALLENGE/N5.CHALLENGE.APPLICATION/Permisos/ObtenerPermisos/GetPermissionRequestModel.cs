using MediatR;

namespace N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos
{
    public record GetPermissionRequestModel : IRequest<ObtenerPermisosResponseDTO>
    {
        public string? NombreEmpleado { get; set; }
        public string? ApellidoEmpleado { get; set; }
    }
}
