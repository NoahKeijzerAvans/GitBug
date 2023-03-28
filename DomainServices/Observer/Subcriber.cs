using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Observer
{
    public class Subscriber
    {
        private List<IObserver> observers= new();

        public void subscribe(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
           
        }
        public void unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void notify(String message)
        {
            foreach(IObserver observer in observers){
                observer.update(message);
            }
        }

    }
}
