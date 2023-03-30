using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public class PartialProductSprintFactory : SprintFactory
    {
        public override Sprint CreateSprint(DateOnly startDate, DateOnly endDate)
        {
            return new PartialProductSprint(startDate, endDate);

        }
    }
}
