using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DomainServices.Context.Task;
using DomainServices.Interfaces.Observer;
using DomainServices.Thread;

namespace DomainServices.Observer
{
    public class IssueThread : Subscriber
    {
        private readonly Issue Issue;
        private List<string> Comments;

        public IssueThread(Issue issue, Person creator)
        {
            Issue = issue;
            Comments = new List<string>();
            Subscribe(creator);
        }
        public void AddComment(Person person, string comment)
        {
            Comments.Add(comment);
            Update(null);
            Subscribe(person);
        }
        public void PrintThread()
        {
            Console.WriteLine($"{Issue.Name}");
            foreach (var comment in Comments)
                Console.WriteLine($"{comment}");

        }
    }
}
