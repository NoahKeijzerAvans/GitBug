// See https://aka.ms/new-console-template for more information
using DomainServices.Observer;

Subscriber subscriber= new Subscriber();
MailNotification mail = new MailNotification();
MailNotification mail2 = new MailNotification();
IObserver slak = new SlakNotification();

subscriber.subscribe(mail);
subscriber.subscribe(slak);
subscriber.unsubscribe(mail2);

subscriber.notify("Kaas");
