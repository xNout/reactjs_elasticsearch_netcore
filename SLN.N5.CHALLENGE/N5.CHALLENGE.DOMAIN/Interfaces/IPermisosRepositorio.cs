using N5.CHALLENGE.DOMAIN.DTOs;

namespace N5.CHALLENGE.DOMAIN.Interfaces
{
    public interface IPermisosRepositorio
    {
        Task<List<PermissionDTO>> GetAll();
        Task<int> Create(PermissionInfoModel Model);
        Task<bool> Modify(int Id, PermissionInfoModel Model);
    }
}
