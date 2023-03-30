using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public abstract class SprintFactory
    {
        public abstract Sprint CreateSprint(DateOnly startDate, DateOnly endDate);
        
    }
}
