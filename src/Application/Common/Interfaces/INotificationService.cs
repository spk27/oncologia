using Oncologia.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Oncologia.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
