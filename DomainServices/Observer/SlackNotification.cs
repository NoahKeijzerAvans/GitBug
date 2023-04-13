using DomainServices.Interfaces.Notifications;

namespace DomainServices.Observer;

public class SlackNotification : INotificationStrategy

{
    public void Update(object? data)
    {
        Console.WriteLine(data!.ToString() + "_SLAK");
    }
}
