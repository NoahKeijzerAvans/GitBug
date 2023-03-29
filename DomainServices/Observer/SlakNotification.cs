﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Observer
{
    public class SlakNotification : INotificationStrategy

    {
        public void Update(object? data)
        {
            Console.WriteLine(data!.ToString() + "_SLAK");
        }
    }
}
