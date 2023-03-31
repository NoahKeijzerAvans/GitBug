using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Models;
using Domain.Models.Comments;
using DomainServices.Context.Task;
using DomainServices.Interfaces.Issue;
using DomainServices.Interfaces.Observer;
using DomainServices.States.IssuesState;
using DomainServices.Thread;
using Xamarin.Forms.Internals;

namespace DomainServices.Observer
{
    public class IssueThread : Subscriber
    {
        private readonly Issue Issue;
        private bool EnterPressed { get; set; }
        private Position StartPos;
        private List<Dictionary<Comment, Position>> commentsPosition;
        private Comment Comment;

        public IssueThread(Issue issue, Person creator)
        {
            StartPos = new Position();
            commentsPosition = new List<Dictionary<Comment, Position>>();
            Issue = issue;
            Comment = new Comment(creator, null, Issue.Name);
            Subscribe(creator);
        }
        public void AddComment(Person creator, string content)
        {
            Comment.Children.Add(new Comment(creator, Comment, content));
            Update(null);
            Subscribe(creator);
        }
        public void PrintThreadWithoutReplyOption(Comment? comment, int level = 0)
        {
            Console.Clear();
            Console.WriteLine();
            if(Issue.State!.GetType() == typeof(DoneState))
              Console.WriteLine($"{Issue.Name} (Closed)");
            else 
                Console.WriteLine($"{Issue.Name}");
            StartPos.Left = Console.CursorLeft;
            StartPos.Top = Console.CursorTop;
            PrintDeptWithoutReplyOption(null);

            if (Issue.State!.GetType() != typeof(DoneState))
            {
                Console.WriteLine("Interact with thread? y/n");
                var response = Console.ReadLine()!;
                if (response.Equals("y"))
                {
                    PrintThreadWithReplyOption(null);
                    SelectCommentToReply();
                }
            }          
        }
        private void PrintDeptWithoutReplyOption(Comment? comment, int level=0)
        {
            if (comment == null)
            {
                comment = Comment;
                level = 1;
            }

            comment!.Children.ForEach(c =>
            {
                for (int i = 0; i < level; i++)
                    Console.Write("  ");
                Console.Write(c);

                for (int i = 0; i <= level; i++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine();

                if (c.Children.Count() > 0)
                    PrintDeptWithoutReplyOption(c, (level + 1));
            });
        }
        public void PrintThreadWithReplyOption(Comment? comment, int level = 0)
        {
            Console.Clear();
            Console.SetCursorPosition(StartPos.Left, StartPos.Top -1);
            Console.WriteLine();
            Console.WriteLine(Issue.Name);
            PrintDeptWithReplyOption(null);
            SelectCommentToReply();
        }
        private void PrintDeptWithReplyOption(Comment? comment, int level = 0)
        {
            if (comment == null)
            {
                comment = Comment;
                level = 1;
            }

            comment!.Children.ForEach(c =>
            {
                for (int i = 0; i < level; i++)
                    Console.Write("  ");
                Console.WriteLine(c);

                for (int i = 0; i <= level; i++)
                {
                    Console.Write("  ");
                }
                Console.Write("[ ] Reply?");
                var newPosition = new Dictionary<Comment, Position>
                {
                    { c, new Position(Console.CursorLeft, Console.CursorTop) }
                };
                commentsPosition.Add(newPosition);
                Console.WriteLine();

                if (c.Children.Count() > 0)
                    PrintDeptWithReplyOption(c, (level + 1));
            });
        }
        private void SelectCommentToReply()
        {
            var commentSelected = commentsPosition.FirstOrDefault();
            var indexSelected = commentsPosition.IndexOf(commentSelected!);

            while (!EnterPressed)
            {
                var Top = GetNewPosition(indexSelected).Top;
                var Left = GetNewPosition(indexSelected).Left;

                if (indexSelected == 0)
                {
                    Console.SetCursorPosition(Left - 10, Top);
                    Console.Write("[X] Reply?");
                }
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(Left - 10, Top);
                        Console.Write("[ ] Reply?");
                        if (CheckIfOutOfBoundsDown(indexSelected, commentsPosition))
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
                            indexSelected = commentsPosition.Count -1;
                        else
                            indexSelected--;
                        SetCursorOnPosition(indexSelected);
                        Console.Write("[X] Reply?");
                        break;
                    case ConsoleKey.Enter:
                        EnterPressed = true;
                        Console.SetCursorPosition(Left - 10, Top);
                        Console.Write("Reply:    ");
                        var content = Console.ReadLine()!;
                        CreateNewComment(content, indexSelected);
                        Console.Clear();
                        PrintThreadWithoutReplyOption(Comment);
                        break;
                }
            }
            EnterPressed = false;
        }
        private void SetCursorOnPosition(int index)
        {
            Console.SetCursorPosition(GetNewPosition(index).Left - 10, GetNewPosition(index).Top);
        }
        private Position GetNewPosition(int index)
        {
            return commentsPosition![index].FirstOrDefault().Value;
        }
        private bool CheckIfOutOfBoundsDown(int index, List<Dictionary<Comment, Position>> commentsPosition)
        {
            if (index + 1 >= commentsPosition.Count)
                return false;
            return true;
        }
        private bool CheckIfOutOfBoundsUp(int index)
        {
            if (index - 1 < 0)
                return true;
            return false;
        }
        private void CreateNewComment(string content, int indexSelected)
        {
            var parent = IterateThroughChildren(Comment, indexSelected);
            var creator = new Person(new MailNotification(), "Noah de Keijzer", "noah.cristiaan@gmail.com");
            var commentToAdd = new Comment(creator, parent, content);
            parent.AddComment(commentToAdd);
            Update(null);
            Subscribe(creator);
            commentsPosition.Clear();
        }
        private Comment IterateThroughChildren(Comment comment, int indexSelected)
        {
            var found = new Comment();
            var toBeFound = commentsPosition![indexSelected].FirstOrDefault().Key;

            foreach (var c in comment.Children)
            {
                if (c == toBeFound)
                {
                    found = c;
                    break;
                }
                else
                   found = IterateThroughChildren(c, indexSelected);
            }
            return found;
        }
    }
}
