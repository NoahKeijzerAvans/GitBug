﻿namespace DomainServices.Interfaces.Issue;

public interface IIssueStateable
{
    // ReSharper disable once UnusedMemberInSuper.Global
    public void SetIssueToDo();
    // ReSharper disable once UnusedMemberInSuper.Global
    public void SetIssueToInProgress();
    // ReSharper disable once UnusedMemberInSuper.Global
    public void SetIssueToDone();
    // ReSharper disable once UnusedMemberInSuper.Global
    public void SetIssueToReadyForTesting();
    // ReSharper disable once UnusedMemberInSuper.Global
    public void SetIssueToCanceled();
    public void SetIssueToTested();
}