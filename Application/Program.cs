// See https://aka.ms/new-console-template for more information

using DomainServices.Context;
using DomainServices.Utils;

var project = new Project("Test", false, "test environment");
var control = new CommandControl(project);
control.Listen();