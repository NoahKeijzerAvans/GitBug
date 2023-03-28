using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Observer
{
    public class Issue
    {
        private Thread thread;
        public Thread addThread()
        {
            return new Thread();
        }
        public void addComment(string comment, string choiceOfNotification)
        {
            IObserver observer = new SlakNotification();
            thread.subscribe(observer);
            thread.addComment(comment);
            thread.notify(comment);

        }
    }
}
