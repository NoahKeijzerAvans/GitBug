using DomainServices.Context;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DomainServices.GitCommands.Commands
{
    public class GitCloneCommand : GitCommand
    {
        public GitCloneCommand(Project context) : base(context)
        {
        }

        public override void Excecute(object? param)
        {
            var localPath = "C:\\source\\SOFA3\\repos\\";
            Console.Write("Provide the url for cloning: ");
            var cloneUrl = Console.ReadLine();
            try
            {
                Repository.Clone(cloneUrl, localPath);
            }
            catch
            {
                Console.Write("Clone not possible, please provide a valid url");
            }
        }
    }
}
