using MediatR;
using Oncologia.Application.Common.Interfaces;
using Oncologia.Application.Notifications.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Oncologia.Application.Pacientes.Commands.UpsertPaciente
{
    public class UpsertPacienteNotification : INotification
    {
        public int PacienteId { get; set; }
        public string Accion { get; set; }
        public string Nombre { get; set; }

        public class UpsertPacienteNotificationHandler : INotificationHandler<UpsertPacienteNotification>
        {
            private readonly INotificationService _notification;

            public UpsertPacienteNotificationHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(UpsertPacienteNotification notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}
