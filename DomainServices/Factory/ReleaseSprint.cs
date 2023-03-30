﻿using DomainServices.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public class ReleaseSprint:  Sprint
    {
        public ReleaseSprint(string name) : base(name)
        {
        }

        public void print()
        {
            Console.WriteLine("test");
        }
    }
}
