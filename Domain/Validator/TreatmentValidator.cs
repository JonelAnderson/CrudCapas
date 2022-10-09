using Entities.Entities;
using FluentValidation;
namespace Domain.Validator
{
    public class TreatmentValidator : AbstractValidator<Tratamiento>
    {
        public TreatmentValidator()
        {
            RuleFor(x => x.Tipo).MinimumLength(4).WithMessage("El Tipo debe conetner mínimo de 4 caracteres")
                .MaximumLength(50).WithMessage("El Tipo no debe conetner más de 50 caracteres")
                .NotNull().WithMessage("El campo Tipo no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Tipo es requerido.");

            RuleFor(x => x.Medicamento).MinimumLength(4).WithMessage("El Medicamento debe conetner mínimo de 4 caracteres")
                .MaximumLength(50).WithMessage("El Medicamento no debe conetner más de 100 caracteres")
                .NotNull().WithMessage("El campo Medicamento no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Medicamento es requerido.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(255).WithMessage("El nombre no debe conetner más de 255 caracteres");

            RuleFor(x => x.IdUser)
                .NotNull().WithMessage("El campo Usuario no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Usuario es requerido.");

        }
    }
}
