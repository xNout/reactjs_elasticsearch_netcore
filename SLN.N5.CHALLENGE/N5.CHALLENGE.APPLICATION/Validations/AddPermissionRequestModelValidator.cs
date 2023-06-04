using FluentValidation;
using N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.APPLICATION.Validations
{
    public class AddPermissionRequestModelValidator : AbstractValidator<AddPermissionRequestModel>
    {
        public AddPermissionRequestModelValidator()
        {
            RuleFor(model => model.NombreEmpleado)
                .NotEmpty().WithMessage("El nombre del empleado es requerido.");

            RuleFor(model => model.ApellidoEmpleado)
                .NotEmpty().WithMessage("El apellido del empleado es requerido.");

            RuleFor(model => model.TipoPermiso)
                .NotEmpty().WithMessage("El tipo de permiso es requerido.");

            RuleFor(model => model.FechaPermiso)
                .NotEmpty().WithMessage("La fecha de permiso es requerida.")
                .Must(BeAValidDate).WithMessage("La fecha de permiso debe ser una fecha válida.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.MinValue && date < DateTime.MaxValue;
        }
    }
}
