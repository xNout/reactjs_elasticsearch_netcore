using N5.CHALLENGE.DOMAIN.DTOs;

namespace N5.CHALLENGE.DOMAIN.Interfaces
{
    public interface ITipoPermisosRepositorio
    {
        Task<List<TipoPermisoInfoDTO>> GetAll();
        Task<string?> GetDescription(int Id);
    }
}
