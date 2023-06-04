using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos;

namespace N5.CHALLENGE.APPLICATION.Validations
{

    public class GetPermissionRequestModelValidator : AbstractValidator<GetPermissionRequestModel>
    {
        public GetPermissionRequestModelValidator()
        {

            RuleFor(model => model.NombreEmpleado)
                .NotEmpty().WithMessage("El nombre del empleado es requerido.");

            RuleFor(model => model.ApellidoEmpleado)
                .NotEmpty().WithMessage("El apellido del empleado es requerido.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.MinValue && date < DateTime.MaxValue;
        }
    }

}
