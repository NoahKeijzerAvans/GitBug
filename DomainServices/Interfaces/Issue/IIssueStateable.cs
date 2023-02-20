﻿namespace DomainServices.Interfaces.Issue;

public interface IIssueStateable
{
    public void SetIssueToDo();
    public void SetIssueToInProgress();
    public void SetIssueToDone();
    public void SetIssueToReview();
    public void SetIssueToCanceled();
}