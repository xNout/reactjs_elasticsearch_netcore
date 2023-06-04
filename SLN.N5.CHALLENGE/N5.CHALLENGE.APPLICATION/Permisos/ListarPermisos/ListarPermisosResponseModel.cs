using N5.CHALLENGE.DOMAIN.DTOs;

namespace N5.CHALLENGE.APPLICATION.Permisos.ListarPermisos
{
    public record ListarPermisosResponseModel
    {
        public ListarPermisosResponseModel()
        {
            Permisos = new();
        }

        public List<PermissionDTO> Permisos { get; set; }
        public string? mensajeError { get; set; }
    }
}
