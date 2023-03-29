using DomainServices.Interfaces.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Context.Pipeline
{
    public class Pipeline :IPipeline
    {
        private readonly List<IPipelineStep> steps;
        public Pipeline()
        {
            steps = new List<IPipelineStep>();
        }

        public void Attach(IPipelineStep step)
        {
            steps.Add(step);
           // Console.WriteLine($"Added {step} to pipeline.");
        }

        public void Detach(IPipelineStep step)
        {
            throw new NotImplementedException();
        }

        public void Excecute()
        {
            steps.ForEach(s => s.Excecute());
        }
    }
}
