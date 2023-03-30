using DomainServices.Interfaces.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public class PartialProductSprint : Sprint
    {
        public PartialProductSprint(DateOnly startDate, DateOnly endDate) : base(startDate, endDate)
        {
            
        }

      
        public override void SetPipeline(IPipeline pipeline)
        {
            throw new NotImplementedException();
        }
    }
}
