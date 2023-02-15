// See https://aka.ms/new-console-template for more information

using Domain.Models;
using DomainServices.Utils;

var changes = new List<Change>
{
    new Change()
};
var newChanges = new List<Change>
{
    new Change()
};

var changeTracker = new ChangesTracker();
changeTracker.AddChanges(changes);
changeTracker.AddChanges(newChanges);
changeTracker.CommitChanges(changeTracker.Changes);
changeTracker.AddChanges(newChanges);
changeTracker.AddChanges(newChanges);
changeTracker.CommitChanges(changeTracker.Changes);
// changeTracker.Commits.ForEach(c => Console.WriteLine(c.ToString()));



