using DomainServices.Thread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Thread.Comments
{
    public class Comment
    {
        private Guid Id = new Guid();
        private Comment Parent;
        private DateTime Created = DateTime.UtcNow;
        private Person Creator;
        public string Content;
        public List<Comment> Children;

        public Comment(Person creator, Comment? parent, string content)
        {
            Parent = parent;
            Creator = creator;
            Content = content;
            Children = new List<Comment>();
        }

        public Comment()
        {
        }

        public void AddComment(Comment comment)
        {
            comment.Parent = this;
            Children.Add(comment);
        }
        public override string ToString()
        {
            return $"{Creator.Name} at {Created}: {Content}";
        }
    }
}
