using FluentValidation;

namespace Oncologia.Application.Pacientes.Commands.UpsertPaciente
{
    public class UpsertPacienteCommandValidator : AbstractValidator<UpsertPacienteCommand>
    {
        public UpsertPacienteCommandValidator()
        {
            
            RuleFor(x => x.PrimerNombre)
                .MaximumLength(50).WithMessage("El primer nombre excede el límite de 50 caracteres.")
                .NotEmpty().WithMessage("El primer nombre no puede ir vacío.");
            RuleFor(x => x.SegundoNombre).MaximumLength(50);
            RuleFor(x => x.PrimerApellido).MaximumLength(50).NotEmpty();
            RuleFor(x => x.SegundoApellido).MaximumLength(50);
            RuleFor(x => x.Cedula).MaximumLength(15).NotEmpty();
        }
    }
}
