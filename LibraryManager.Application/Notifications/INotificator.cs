using LibraryManager.Application.Notifications;

namespace LibraryManager.Core.Interfaces;

public interface INotificator
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}
