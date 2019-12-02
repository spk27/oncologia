using FluentValidation;

namespace Oncologia.Application.Pacientes.Commands.DeletePaciente
{
    public class DeletePacienteCommandValidator : AbstractValidator<DeletePacienteCommand>
    {
        public DeletePacienteCommandValidator()
        {
            
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
