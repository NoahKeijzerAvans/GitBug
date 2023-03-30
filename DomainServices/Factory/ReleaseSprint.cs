using DomainServices.Interfaces.Pipeline;
using DomainServices.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public class ReleaseSprint:  Sprint
    {
        public ReleaseSprint(DateOnly startDate, DateOnly endDate) : base(startDate, endDate)
        {
        }

        public void print()
        {
            Console.WriteLine("test");
        }
        public override void SetPipeline(IPipeline pipeline)
        {

        }
    }
}
