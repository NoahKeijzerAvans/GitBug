using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Interfaces.Observer;

namespace DomainServices.Interfaces.Notifications
{
    public interface INotificationStrategy : IObserver
    {
    }
}
