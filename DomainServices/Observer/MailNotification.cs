using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Interfaces.Notifications;

namespace DomainServices.Observer
{
    public class MailNotification: INotificationStrategy
    {
        public void Update(object? data)
        {
            //send the notification
            Console.WriteLine("Mail send: "+ data!.ToString());
        }
    }
}
