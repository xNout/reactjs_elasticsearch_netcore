using Microsoft.AspNetCore.Mvc;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.APPLICATION.Permisos.ListarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos;

namespace N5.CHALLENGE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {

        private readonly IPermisosAppService _permisosAppService;

        public PermisosController(IPermisosAppService permisosAppService)
        {
            _permisosAppService = permisosAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddPermissionRequestModel request)
        {
            AddPermissionResponseModel response = await _permisosAppService.Create(request);

            return Ok(response);
        }
        [HttpPost("Obtener")]
        public async Task<IActionResult> Obtener(GetPermissionRequestModel request)
        {
            ObtenerPermisosResponseDTO response = await _permisosAppService.ObtenerPermiso(request);

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ListarPermisosResponseModel response = await _permisosAppService.ObtenerTodos(new ListarPermisosRequestModel());

            return Ok(response);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Index(int Id, ModifyPermissionRequestModel request)
        {
            request.Id = Id;
            ModifyPermissionResponseModel response = await _permisosAppService.Modify(request);

            return Ok(response);
        }


    }
}
