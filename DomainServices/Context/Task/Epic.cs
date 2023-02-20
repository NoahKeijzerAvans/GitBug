﻿using Domain;
using Domain.Enums;
using Domain.Models;
using DomainServices.Interfaces;

namespace DomainServices.Context.Task;

public class Epic: Issue
{
    private string Summary { get; set; }

    public Epic(string name, string description, Project project, DateTime dateAdded, Priority priority, string summary, string requestType, List<Issue>? subTasks) : base(name, description, project, 0, null, dateAdded, priority, subTasks)
    {
        Summary = summary;
    }
}