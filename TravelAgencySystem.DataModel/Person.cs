namespace TravelAgencySystem.DataModel;

public abstract class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pesel { get; set; }
}

