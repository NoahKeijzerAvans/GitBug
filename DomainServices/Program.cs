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

Factory factory = new ReleaseSprintFactory();
Sprint kaas = factory.CreateSprint();
kaas.print();
