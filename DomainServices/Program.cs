// See https://aka.ms/new-console-template for more information
using DomainServices.Observer;
using DomainServices.Factory;

Subscriber subscriber= new DomainServices.Observer.Thread();
MailNotification mail = new MailNotification();
MailNotification mail2 = new MailNotification();
IObserver slak = new SlakNotification();

subscriber.subscribe(mail);
subscriber.subscribe(slak);
subscriber.unsubscribe(mail2);

subscriber.notify("Kaas");

Factory factory = new ReleaseSprintFactory();
ISprint kaas = factory.createSprint();
kaas.print();
