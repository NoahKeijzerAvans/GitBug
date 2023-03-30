using Domain.Enums;
using DomainServices.Context;
using DomainServices.Context.Task;
using DomainServices.Observer;

namespace DomainServices.Factory
{
    public abstract class Sprint : Subscriber
    {
        public SprintStatus SprintStatus { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public CompositeIssue CompositeIssue { get; set; }
        public List<IssueThread> Threads { get; set; }
        public ScrumBoard Scumboard { get; set; }

        public Sprint(string name)
        {
            SprintStatus = SprintStatus.OPEN;
            Name = name;
            Threads = new List<IssueThread>();
            CompositeIssue = new CompositeIssue(Name, $"{DateStart.Date} - {DateEnd.Date} ");
            Scumboard = new ScrumBoard(CompositeIssue);
        }
        public void ShowThreads()
        {
            Threads.ForEach(t =>
            {
                t.PrintThreadWithoutReplyOption(null);
            });
        }
        public void AddIssue(Issue issue)
        {
            CompositeIssue.Add(issue);
        }
        public void Print()
        {
            Console.WriteLine();
        }
        public void CloseSprint()
        {
            SprintStatus = SprintStatus.FINISHED;
        }
        public void StartSprint()
        {
            SprintStatus = SprintStatus.INPROGRESS;
        }
    }
}
