using Microsoft.AspNetCore.Mvc;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.APPLICATION.Permisos.ListarPermisos;
using N5.CHALLENGE.APPLICATION.TipoPermisos.ListarTipoPermisos;

namespace N5.CHALLENGE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisoController : ControllerBase
    {

        private readonly IPermisosAppService _permisosAppService;

        public TipoPermisoController(IPermisosAppService permisosAppService)
        {
            _permisosAppService = permisosAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ListarTipoPermisoResponseModel response = await _permisosAppService.ObtenerTiposPermiso(new ListarTipoPermisoRequestModel());

            return Ok(response);
        }
    }
}
