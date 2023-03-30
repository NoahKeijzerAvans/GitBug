// See https://aka.ms/new-console-template for more information
using DomainServices.Observer;
using DomainServices.Factory;

Subscriber subscriber= new DomainServices.Observer.Thread();
IObserver mail = new MailNotification();
IObserver slak = new SlakNotification();

var thread = new DomainServices.Observer.Thread();
thread.subscribe(mail);


subscriber.subscribe(mail);
subscriber.subscribe(slak);
subscriber.notify("Kaas");

SprintFactory factory = new ReleaseSprintFactory();
Sprint sprint = factory.CreateSprint(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(1)));
sprint.Print("Test Facotry");
