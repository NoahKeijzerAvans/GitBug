using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Observer
{
    public class Issue
    {
        private readonly Thread Thread;
        public Thread addThread()
        {
            return new Thread();
        }
        public void addComment(string comment, string choiceOfNotification)
        {
            IObserver observer = new SlakNotification();
            Thread.Subscribe(observer);
            Thread.addComment(comment);
            Thread.Update(comment);
        }
    }
}
