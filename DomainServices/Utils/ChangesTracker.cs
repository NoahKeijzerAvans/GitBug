using DomainServices.Context.Commands;
using DomainServices.Interfaces.Change;
using DomainServices.States.ChangesState;

namespace DomainServices.Utils;

public class ChangesTracker
{
    public Branch CurrentBranch { get; set; }
    public List<Branch> Branches { get;}
    public List<Change> Changes { get; }

    public ChangesTracker()
    {
        CurrentBranch = new Branch("master");
        Branches = new List<Branch> { CurrentBranch };
        Changes = new List<Change>();
    }

   
}
