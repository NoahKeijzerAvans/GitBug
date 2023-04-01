using DomainServices.Interfaces.Observer;

namespace DomainServices.Pipeline
{
    public abstract class PipelineStep : IObserver
    {
        public bool IsSucceeded { get; set; }

        public override string ToString()
        {
            return base.ToString()!;
        }

        public void Update(object? data)
        {
            throw new NotImplementedException();
        }
    }
}