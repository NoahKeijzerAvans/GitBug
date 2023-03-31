using Domain.Enums;
using DomainServices.Thread;
using DomainServices.Context.Task;
using DomainServices.States.IssuesState;

namespace Test.IssueStates
{
    public sealed class TodoStateTests
    {
        private Issue _issue;
        public TodoStateTests()
        {
            _issue = new Story("New Story", "Example", 5, new Person(), Priority.High, String.Empty,
                "when the task is finished the task is finished", new List<Issue>());
            _issue.State = new ToDoState(_issue);

        }

        private void Setup()
        {
            _issue = new Story("New Story", "Example", 5, new Person(), Priority.High, String.Empty,
                "when the task is finished the task is finished", new List<Issue>());
            _issue.State = new ToDoState(_issue);
        }

        [Fact]
        public void Should_Throw_Invalid_Operation_Exception_When_Set_To_Do_Is_Called()
        {
            // Arrange
            Setup();
            // Act
            void TestCode() => _issue.SetIssueToDo();
            // Assert
            Assert.Throws<InvalidOperationException>(TestCode);
        }

        [Fact]
        public void Should_Throw_Invalid_Operation_When_Set_Issue_To_Review_Is_Called()
        {
            // Arrange
            Setup();
            // Act
            try
            {
                _issue.SetIssueToReadyForTesting();
            }
            catch (Exception e)
            {
                // Assert
                Assert.IsType<InvalidOperationException>(e);
            }
        }

        [Fact]
        public void Should_Change_State_To_In_Progress_When_Set_Issue_To_In_Progress_Is_Called()
        {
            // Arrange
            Setup();
            // Act
            _issue.SetIssueToInProgress();
            var sut = _issue.State;

            // Assert
            Assert.IsType<InProgressState>(sut);
        }

        [Fact]
        public void Should_Throw_Invalid_Operation_When_Set_Issue_To_Done_Is_Called()
        {
            // Arrange
            Setup();

            // Act
            try
            {
                _issue.SetIssueToDone();
            }
            catch (Exception e)
            {
                // Assert
                Assert.IsType<InvalidOperationException>(e);
            }
        }
        [Fact]
        public void Should_Throw_Invalid_Operation_When_Set_Issue_To_Canceled_Is_Called()
        {
            // Arrange
            Setup();

            // Act
            try
            {
                _issue.SetIssueToCanceled();
            }
            catch (Exception e)
            {
                // Assert
                Assert.IsType<InvalidOperationException>(e);
            }
        }
    }
}
