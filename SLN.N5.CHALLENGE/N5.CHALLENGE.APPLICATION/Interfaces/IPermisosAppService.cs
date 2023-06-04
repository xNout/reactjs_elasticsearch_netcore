using N5.CHALLENGE.APPLICATION.Permisos.ListarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos;
using N5.CHALLENGE.APPLICATION.TipoPermisos.ListarTipoPermisos;

namespace N5.CHALLENGE.APPLICATION.Interfaces
{
    public interface IPermisosAppService
    {
        Task<ListarTipoPermisoResponseModel> ObtenerTiposPermiso(ListarTipoPermisoRequestModel Model);
        Task<ListarPermisosResponseModel> ObtenerTodos(ListarPermisosRequestModel Model);
        Task<ModifyPermissionResponseModel> Modify(ModifyPermissionRequestModel Model);
        Task<AddPermissionResponseModel> Create(AddPermissionRequestModel Model);
        Task<ObtenerPermisosResponseDTO> ObtenerPermiso(GetPermissionRequestModel Model);
    }
}
