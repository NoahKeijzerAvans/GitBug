using DomainServices.Interfaces.Observer;

namespace DomainServices.Observer
{
    public abstract class Subscriber
    {
        private List<IObserver> Observers= new();

        public void Subscribe(IObserver observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
           
        }
        public void Unsubscribe(IObserver observer)
        {
            Observers.Remove(observer);
        }
        public void Update(object? param)
        {
            foreach (IObserver observer in Observers)
            {
                observer!.Update(param);
            }
        }      
    }
}
