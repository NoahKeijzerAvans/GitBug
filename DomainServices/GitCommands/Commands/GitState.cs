using DomainServices.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.GitCommands.Commands;

public class GitState : GitCommand
{
    public GitState(Project context) : base(context)
    {
    }

    public override void Excecute(object? param)
    {
        Console.WriteLine($"Current state: {Context.GetCurrentState()}");
    }
}
