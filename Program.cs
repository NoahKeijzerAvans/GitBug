﻿// See https://aka.ms/new-console-template for more information

using Domain.Models;
using DomainServices.Utils;

var changeTracker = new ChangesTracker();
changeTracker.GetCurrentBranch();
changeTracker.CreateBranch();

changeTracker.AddChange(new Change());
changeTracker.AddChange(new Change());
changeTracker.CommitChanges();

changeTracker.AddChange(new Change());
changeTracker.AddChange(new Change());
changeTracker.CommitChanges();

var idk = "hello";




