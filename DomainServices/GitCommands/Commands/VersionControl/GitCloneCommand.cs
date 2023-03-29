using DomainServices.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DomainServices.GitCommands.Commands.VersionControl
{
    public class GitCloneCommand : GitCommand
    {
        public GitCloneCommand(Project context) : base(context)
        {
        }

        public override void Excecute(object? param)
        {
            Console.WriteLine("Repository cloned sucessfully");
        }
    }
}
