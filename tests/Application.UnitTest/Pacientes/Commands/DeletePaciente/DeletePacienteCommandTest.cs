using MediatR;
using Moq;
using Oncologia.Application.Pacientes.Commands.DeletePaciente;
using System.Threading;
using Oncologia.Application.UnitTests.Common;
using Xunit;
using Oncologia.Application.Common.Exceptions;
using System.Threading.Tasks;

namespace Oncologia.Application.UnitTests.Pacientes.Commands.DeletePaciente 
{
    public class DeletePacienteTest : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenNoExistingId_ShouldThrowNotFoundException()
        {
            var _sut = new DeletePacienteCommand.DeletePacienteCommandHandler(_context);
            var noExistingId = 1003;
            var _command = new DeletePacienteCommand {
                Id = noExistingId
            };
            
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(_command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidPacienteId_ShouldDeleteAndReturnNull()
        {
            var _sut = new DeletePacienteCommand.DeletePacienteCommandHandler(_context);
            var existingId = 1002;
            var _command = new DeletePacienteCommand {
                Id = existingId
            };
            
            await _sut.Handle(_command, CancellationToken.None);

            var paciente = await _context.Pacientes.FindAsync(existingId);

            Assert.Null(paciente);
        }
    }
}