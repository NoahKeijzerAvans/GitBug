﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public class ReleaseSprint: ISprint
    {
        public void print()
        {
            Console.WriteLine("test");
        }
    }
}
