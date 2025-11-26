using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IEmployeeService
{
    Guid Create(string firstName, string lastName, string pesel, double salary);
    Employee? Get(Guid id);
    IReadOnlyList<Employee> GetAll();
}