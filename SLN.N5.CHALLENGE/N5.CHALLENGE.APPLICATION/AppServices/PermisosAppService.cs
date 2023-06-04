using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.APPLICATION.Permisos.ListarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos;
using N5.CHALLENGE.APPLICATION.TipoPermisos.ListarTipoPermisos;
using N5.CHALLENGE.APPLICATION.Validations;

namespace N5.CHALLENGE.APPLICATION.AppServices
{
    public class PermisosAppService : IPermisosAppService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public PermisosAppService(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }


        public async Task<AddPermissionResponseModel> Create(AddPermissionRequestModel Model)
        {
            AddPermissionRequestModelValidator validator = new();
            ValidationResult validationResult = validator.Validate(Model);

            if (!validationResult.IsValid)
            {
                string Errores = string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                return new AddPermissionResponseModel()
                {
                    mensajeError = Errores
                };
            }

            return await _mediator.Send(Model);
        }

        public async Task<ModifyPermissionResponseModel> Modify(ModifyPermissionRequestModel Model)
        {

            ModifyPermissionRequestModelValidator validator = new();
            ValidationResult validationResult = validator.Validate(Model);

            if (!validationResult.IsValid)
            {
                string Errores = string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                return new ModifyPermissionResponseModel()
                {
                    mensajeError = Errores
                };
            }

            return await _mediator.Send(Model);
        }
        public async Task<ObtenerPermisosResponseDTO> ObtenerPermiso(GetPermissionRequestModel Model)
        {
            GetPermissionRequestModelValidator validator = new();
            ValidationResult validationResult = validator.Validate(Model);

            if (!validationResult.IsValid)
            {
                string Errores = string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                return new ObtenerPermisosResponseDTO()
                {
                    mensajeError = Errores
                };
            }

            return await _mediator.Send(Model);
        }

        public async Task<ListarPermisosResponseModel> ObtenerTodos(ListarPermisosRequestModel Model)
        {
            return await _mediator.Send(Model);
        }

        public async Task<ListarTipoPermisoResponseModel> ObtenerTiposPermiso(ListarTipoPermisoRequestModel Model)
        {
            return await _mediator.Send(Model);
        }
    }
}
