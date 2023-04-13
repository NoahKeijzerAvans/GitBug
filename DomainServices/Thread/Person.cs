using DomainServices.Interfaces.Notifications;
using DomainServices.Interfaces.Observer;
using DomainServices.Observer;

namespace DomainServices.Thread;

public class Person : IObserver
{
    private INotificationStrategy NotificationStrategy;
    public string Name { get; set; }
    public string Email { get; set; }

    public Person()
    {
        NotificationStrategy = new MailNotification();
        Name = "";
        Email = "";
    }

    public Person(INotificationStrategy notificationStrategy, string name, string email)
    {
        NotificationStrategy = notificationStrategy;
        Name = name;
        Email = email;
    }
    public void Update(object? data)
    {
        NotificationStrategy.Update(Email);
    }
}
