using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Interfaces.Pipeline
{
    public interface IPipeline
    {
        void Excecute();
        void Attach(IPipelineStep step);
        void Detach(IPipelineStep step);
    }
}
