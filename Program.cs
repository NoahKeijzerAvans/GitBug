using DomainServices.Utils;

var changeTracker = new ChangesTracker();
var commandListener = new CommandControl(changeTracker);

commandListener.Listen();



