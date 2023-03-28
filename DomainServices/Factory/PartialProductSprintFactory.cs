using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public class PartialProductSprintFactory : Factory
    {
        public override ISprint createSprint()
        {
            return new PartialProductSprint();
        }
    }
}
