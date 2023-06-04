using N5.CHALLENGE.DOMAIN.DTOs;

namespace N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos
{
    public class ObtenerPermisosResponseDTO
    {
        public PermissionDTO? Permiso { get; set; }
        public string? mensajeError { get; set; }
    }
}
