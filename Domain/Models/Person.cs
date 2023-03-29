namespace Domain.Models;

public class Person
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    private string EmailAdress { get; }
    private string FirstName { get; }
    private string LastName { get; }
    public string FullName => $"{FirstName} {LastName}";

    public Person(string emailAdress, string firstName, string lastName)
    {
        EmailAdress = emailAdress;
        FirstName = firstName;
        LastName = lastName;
    }

#pragma warning disable CS8618
    public Person()
#pragma warning restore CS8618
    {
        
    }
}