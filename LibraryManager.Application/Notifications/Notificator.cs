using LibraryManager.Core.Interfaces;

namespace LibraryManager.Application.Notifications;

public class Notificator : INotificator
{
    private readonly List<Notification> _notifications;

    public Notificator()
    {
        _notifications = new List<Notification>();
    }

    public List<Notification> GetNotifications()
    {
        return _notifications;
    }

    public void Handle(Notification notification)
    {
        _notifications.Add(notification);
    }

    public bool HasNotification()
    {
        return _notifications.Any();
    }
}