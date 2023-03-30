using DomainServices.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.GitCommands.Commands.Thread
{
    public class ShowThreadsCommand : GitCommand
    {
        public ShowThreadsCommand(Project context) : base(context)
        {
        }

        public override void Excecute(object? param)
        {
            throw new NotImplementedException();
        }
    }
}
