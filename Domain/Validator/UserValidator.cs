using Entities.Entities;
using FluentValidation;

namespace Domain.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("El nombre debe conetner mínimo de 4 caracteres")
                .MaximumLength(50).WithMessage("El nombre no debe conetner más de 50 caracteres")
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre es requerido.");


            RuleFor(x => x.LastName).MinimumLength(8).WithMessage("El Apellido debe contener mínimo de 8 caracteres")
                .MaximumLength(50).WithMessage("El Apellido no debe conetner más de 50 caracteres")
                .NotNull().WithMessage("El campo Apellido no puede ser nulo.")
                .NotEmpty().WithMessage("El Apellido es requerido");


            RuleFor(x => x.Email).MaximumLength(100).WithMessage("El nombre no debe contener más de 100 caracteres")
                .NotNull().WithMessage("El campo email no puede ser nulo.")
                .NotEmpty().WithMessage("El email es requerido");


            RuleFor(x => x.Phone).MinimumLength(9).WithMessage("El Teléfono debe contener mínimo de 9 caracteres")
                .MaximumLength(11).WithMessage("El teléfono no debe contener más de 11 caracteres")
                .NotNull().WithMessage("El campo teléfono no puede ser nulo.")
                .NotEmpty().WithMessage("El teléfono es requerido");

        }
    }
}
