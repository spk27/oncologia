using MediatR;
using Moq;
using Oncologia.Application.Pacientes.Commands.UpsertPaciente;
using System.Threading;
using Oncologia.Application.UnitTests.Common;
using Xunit;
using Oncologia.Application.Common.Exceptions;
using System.Threading.Tasks;

namespace Oncologia.Application.UnitTests.Pacientes.Commands.UpsertPaciente 
{
    public class UpsertPacienteTest : CommandTestBase
    {
        private UpsertPacienteCommand _command = new UpsertPacienteCommand 
        { 
            Id = null
            , PrimerNombre = "Daniel"
            , PrimerApellido = "Aguilar"
            , Cedula = "1028999"
            , TipoCedula = "CE"
        };

        [Fact]
        public void Handle_ValidCommandUpsertEdit_ShouldRaiseNotifaction()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new UpsertPacienteCommand.UpsertPacienteCommandHandler(_context, mediatorMock.Object);
            var editPacienteId = 1000;
            _command.Id = editPacienteId;

            // Act
            var result = sut.Handle(_command, CancellationToken.None);


            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<UpsertPacienteNotification>(pc => pc.PacienteId == editPacienteId), It.IsAny<CancellationToken>()), Times.Once);
        }
        
        
        [Fact]
        public void Handle_ValidCommandUpsertCreate_ShouldRaiseNotifaction()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new UpsertPacienteCommand.UpsertPacienteCommandHandler(_context, mediatorMock.Object);
            var nextPacienteId = 1003;
            _command.Id = null;
            // Act
            var result = sut.Handle(_command, CancellationToken.None);


            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<UpsertPacienteNotification>(pc => pc.PacienteId == nextPacienteId), It.IsAny<CancellationToken>()), Times.Once);
        }
        
        [Fact]
        public async Task Handle_NoExistingPacienteIdCommandUpsertEdit_ShouldThrowNotFoundException()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new UpsertPacienteCommand.UpsertPacienteCommandHandler(_context, mediatorMock.Object);
            var noExistingPacienteId = 1003;
            _command.Id = noExistingPacienteId;
            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(_command, CancellationToken.None));
        }
    }
}