using Oncologia.Application.Common.Interfaces;
using Oncologia.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Oncologia.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
