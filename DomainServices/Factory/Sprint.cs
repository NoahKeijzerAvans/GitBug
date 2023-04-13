using Domain.Enums;
using Domain.Models;
using DomainServices.Context;
using DomainServices.Context.Task;
using DomainServices.Observer;
using DomainServices.Thread;

namespace DomainServices.Factory
{
    public abstract class Sprint : Subscriber
    {
        private bool EnterPressed { get; set; }

        private readonly List<Dictionary<Issue, Position>> IssuePosition;
        public SprintStatus SprintStatus { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public CompositeIssue CompositeIssue { get; set; }
        public List<IssueThread> Threads { get; set; }
        public ScrumBoard Scumboard { get; set; }

        public Sprint(string name)
        {
            IssuePosition = new List<Dictionary<Issue, Position>>();
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
        public void AddThread()
        {
            Console.WriteLine("Select the issue you want to start a thread on:");
            var first = true;
            CompositeIssue.Issues.ForEach(i =>
            {
                if (first)
                    Console.WriteLine($"[X] {i.Name}");
                else
                    Console.WriteLine($"[ ] {i.Name}");
                AddNewPosition(i);
            });
            SelectIssue();
        }

        private void SelectIssue()
        {
            var issueSelected = IssuePosition.FirstOrDefault();
            var indexSelected = IssuePosition.IndexOf(issueSelected!);
            var key = Console.ReadKey();
            while (!EnterPressed)
            {
                var Top = GetNewPosition(indexSelected).Top;
                var Left = GetNewPosition(indexSelected).Left;

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(Left - 10, Top);
                        Console.Write("[ ] Reply?");
                        if (CheckIfOutOfBoundsDown(indexSelected, IssuePosition))
                            indexSelected++;
                        else
                            indexSelected = 0;
                        SetCursorOnPosition(indexSelected);
                        Console.Write("[X] Reply?");
                        break;
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(Left - 10, Top);
                        Console.Write("[ ] Reply?");
                        if (CheckIfOutOfBoundsUp(indexSelected))
                            indexSelected = IssuePosition.Count - 1;
                        else
                            indexSelected--;
                        SetCursorOnPosition(indexSelected);
                        Console.Write("[X] Reply?");
                        break;
                    case ConsoleKey.Enter:
                        EnterPressed = true;
                        Console.SetCursorPosition(Left - 10, Top);
                        Console.Write("Reply:    ");
                        CreateNewThread(indexSelected);
                        Console.Clear();
                        break;
                }
            }
            EnterPressed = false;
        }
        private void CreateNewThread(int indexSelected)
        {
            var creator = new Person(new MailNotification(), "Noah de Keijzer", "noah.cristiaan@gmail.com");
            var threadToAdd = new IssueThread(IssuePosition![indexSelected].FirstOrDefault().Key, creator);
            Console.WriteLine("How do you want to start the thread?");
            var content = Console.ReadLine();
            threadToAdd.AddComment(creator, content!);
            threadToAdd.Subscribe(creator);
            Update(null);
            Subscribe(creator);
            IssuePosition.Clear();
        }

        private void AddNewPosition(Issue issue)
        {
            var newPosition = new Dictionary<Issue, Position>
                    {
                        { issue, new Position(Console.CursorLeft, Console.CursorTop) }
                    };
            IssuePosition.Add(newPosition);
        }
        private void SetCursorOnPosition(int index)
        {
            Console.SetCursorPosition(GetNewPosition(index).Left - 10, GetNewPosition(index).Top);
        }
        private Position GetNewPosition(int index)
        {
            return IssuePosition![index].FirstOrDefault().Value;
        }
        private bool CheckIfOutOfBoundsDown(int index, List<Dictionary<Issue, Position>> issuePosition)
        {
            if (index + 1 >= issuePosition.Count)
                return false;
            return true;
        }
        private bool CheckIfOutOfBoundsUp(int index)
        {
            if (index - 1 < 0)
                return true;
            return false;
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
