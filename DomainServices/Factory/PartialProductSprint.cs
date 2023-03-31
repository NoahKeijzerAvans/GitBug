using DomainServices.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public class PartialProductSprint: Sprint
    {
        public PartialProductSprint(string name) : base(name)
        {
        }

        public void print()
        {
            throw new NotImplementedException();
        }
    }
}
