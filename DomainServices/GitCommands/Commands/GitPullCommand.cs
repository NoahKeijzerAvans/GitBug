﻿using DomainServices.Context;
using DomainServices.Utils;

namespace DomainServices.GitCommands.Commands;

public class GitPullCommand : GitCommand
{
    public GitPullCommand(Project context) : base(context)
    {
    }

    public override void Excecute(dynamic? param)
    {
        Context.PullToWorkingDirectory();
    }
}