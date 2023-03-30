using DomainServices.Interfaces.Pipeline;
using DomainServices.Observer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Factory
{
    public abstract class Sprint: Subscriber
    {
        private DateOnly startDate;
        private DateOnly endDate;
        private List<Issue> issues;
        private Boolean isClosed = false;
        private IPipeline ?pipeline;
        public Sprint(DateOnly startDate , DateOnly endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            issues= new List<Issue>();
        }
        public Boolean IsClosed()
        {
            if (this.endDate >= DateOnly.FromDateTime(DateTime.Now)){
                this.isClosed = true;
            }
            return isClosed;
        }
        public void AddIssue(Issue issue)
        {
            if (issue != null) { 
                issues.Add(issue);  
            }

        }
        public List<Issue> GetIssues()
        {
            return issues;
        }
        public void ShowIssue()
        {
            foreach (Issue i in issues)
            {
                Console.WriteLine(i.ToString());
            }
        }
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public abstract void SetPipeline(IPipeline pipeline);
        
         
        
    }
}
