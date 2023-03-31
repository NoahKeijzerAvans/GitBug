using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomainServices.Factory
{
    public abstract class Factory
    {
        public abstract Sprint CreateSprint(string name);
        
    }
}
