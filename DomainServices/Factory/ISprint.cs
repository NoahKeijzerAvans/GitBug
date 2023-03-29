using DomainServices.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public abstract class Sprint: Subscriber
    {
        public void print()
        {
            Console.WriteLine();
        }
    }
}
