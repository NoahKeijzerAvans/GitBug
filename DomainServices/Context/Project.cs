using DomainServices.Context.Commands;
using DomainServices.Utils;
using System.Diagnostics;
using DomainServices.States.ChangesState;
using Domain.Models;

namespace DomainServices.Context;

public class Project
{
    private Guid? ProjectIdGuid { get; set; }
    private List<Person> Contributors { get; set; }
    private List<Branch> Branches { get; set; }
    private string Name { get; set; }
    private bool IsPrivate { get; set; }
    private string Description { get; set; }
    private ChangesTracker Tracker;

    public Project(string name, bool isPrivate, string description)
    {
        Tracker = new ChangesTracker();
        ProjectIdGuid = Guid.NewGuid();
        Contributors = new List<Person>();
        Branches = new List<Branch>
        {
            new ("master", Tracker)
        };
        Name = name;
        IsPrivate = isPrivate;
        Description = description;
    }
}