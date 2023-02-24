namespace Domain.Models;

public class Person
{
    private string EmailAdress { get; set; }
    private string FirstName { get; set; }
    private string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public Person(string emailAdress, string firstName, string lastName)
    {
        EmailAdress = emailAdress;
        FirstName = firstName;
        LastName = lastName;
    }

    public Person()
    {
        
    }
}