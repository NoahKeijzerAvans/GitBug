using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Observer
{
    public class MailNotification: INotificationStrategy
    {
        public void update(String data)
        {
            //send the notification
            Console.WriteLine("Mail send: "+ data);
        }
    }
}
